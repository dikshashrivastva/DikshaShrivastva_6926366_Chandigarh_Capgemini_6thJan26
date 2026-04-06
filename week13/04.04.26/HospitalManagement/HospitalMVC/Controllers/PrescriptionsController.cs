using HospitalMVC.Helpers;
using HospitalMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMVC.Controllers
{
    [Authorize]
    public class PrescriptionsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PrescriptionsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        private HttpClient GetClient()
        {
            var client = _clientFactory.CreateClient("HospitalAPI");
            var token = HttpContext.Session.GetString("JwtToken");
            if (!string.IsNullOrEmpty(token))
                ApiHelper.SetAuthToken(client, token);
            return client;
        }

        public async Task<IActionResult> Index()
        {
            var client = GetClient();
            var response = await client.GetAsync("api/prescriptions");
            var list = new List<PrescriptionViewModel>();
            if (response.IsSuccessStatusCode)
                list = await ApiHelper.DeserializeAsync<List<PrescriptionViewModel>>(response) ?? new();
            return View(list);
        }

        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> Create(int appointmentId)
        {
            var client = GetClient();
            var apptRes = await client.GetAsync($"api/appointments/{appointmentId}");
            var appt = apptRes.IsSuccessStatusCode
                ? await ApiHelper.DeserializeAsync<AppointmentViewModel>(apptRes)
                : null;
            return View(new CreatePrescriptionViewModel
            {
                AppointmentId = appointmentId,
                PatientName = appt?.PatientName ?? ""
            });
        }

        [HttpPost, Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> Create(CreatePrescriptionViewModel model)
        {
            var client = GetClient();
            var response = await client.PostAsync("api/prescriptions", ApiHelper.ToJsonContent(new
            {
                model.AppointmentId,
                model.Diagnosis,
                model.Medicines,
                model.Notes
            }));
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Prescription saved successfully!";
                return RedirectToAction("Index", "Appointments");
            }
            TempData["Error"] = "Failed to save prescription. It may already exist.";
            return View(model);
        }
    }
}
using HospitalMVC.Helpers;
using HospitalMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMVC.Controllers
{
    [Authorize]
    public class BillsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public BillsController(IHttpClientFactory clientFactory)
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
            var response = await client.GetAsync("api/bills");
            var list = new List<BillViewModel>();
            if (response.IsSuccessStatusCode)
                list = await ApiHelper.DeserializeAsync<List<BillViewModel>>(response) ?? new();
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
            return View(new CreateBillViewModel
            {
                AppointmentId = appointmentId,
                PatientName = appt?.PatientName ?? "",
                DoctorName = appt?.DoctorName ?? ""
            });
        }

        [HttpPost, Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> Create(CreateBillViewModel model)
        {
            var client = GetClient();
            var response = await client.PostAsync("api/bills", ApiHelper.ToJsonContent(new
            {
                model.AppointmentId,
                model.ConsultationFee,
                model.MedicineCharges,
                model.PaymentStatus
            }));
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Bill generated successfully!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Failed to generate bill. It may already exist.";
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MarkPaid(int id)
        {
            var client = GetClient();
            await client.PutAsync($"api/bills/{id}/payment",
                ApiHelper.ToJsonContent(new { PaymentStatus = "Paid" }));
            TempData["Success"] = "Bill marked as paid!";
            return RedirectToAction("Index");
        }
    }
}

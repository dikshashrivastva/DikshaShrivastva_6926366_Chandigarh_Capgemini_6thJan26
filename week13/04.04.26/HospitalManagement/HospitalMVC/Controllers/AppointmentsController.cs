using HospitalMVC.Helpers;
using HospitalMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMVC.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public AppointmentsController(IHttpClientFactory clientFactory)
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
            var role = HttpContext.Session.GetString("UserRole");
            var userId = HttpContext.Session.GetInt32("UserId");
            var appointments = new List<AppointmentViewModel>();

            if (role == "Patient" && userId.HasValue)
            {
                var res = await client.GetAsync($"api/appointments/patient/{userId}");
                if (res.IsSuccessStatusCode)
                    appointments = await ApiHelper.DeserializeAsync<List<AppointmentViewModel>>(res) ?? new();
            }
            else
            {
                var res = await client.GetAsync("api/appointments");
                if (res.IsSuccessStatusCode)
                    appointments = await ApiHelper.DeserializeAsync<List<AppointmentViewModel>>(res) ?? new();
            }
            return View(appointments);
        }

        public async Task<IActionResult> Book()
        {
            var client = GetClient();
            var deptRes = await client.GetAsync("api/departments");
            var departments = new List<DepartmentViewModel>();
            if (deptRes.IsSuccessStatusCode)
                departments = await ApiHelper.DeserializeAsync<List<DepartmentViewModel>>(deptRes) ?? new();

            var docRes = await client.GetAsync("api/doctors");
            var doctors = new List<DoctorViewModel>();
            if (docRes.IsSuccessStatusCode)
                doctors = await ApiHelper.DeserializeAsync<List<DoctorViewModel>>(docRes) ?? new();

            var model = new BookAppointmentViewModel
            {
                Departments = departments,
                Doctors = doctors,
                PatientId = HttpContext.Session.GetInt32("UserId") ?? 0
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookAppointmentViewModel model)
        {
            var client = GetClient();
            var patientId = HttpContext.Session.GetInt32("UserId") ?? 0;
            var response = await client.PostAsync("api/appointments", ApiHelper.ToJsonContent(new
            {
                patientId,
                model.DoctorId,
                model.AppointmentDate
            }));
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Appointment booked successfully!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Failed to book appointment.";
            return RedirectToAction("Book");
        }

        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateStatus(int id, string status)
        {
            var client = GetClient();
            await client.PutAsync($"api/appointments/{id}/status",
                ApiHelper.ToJsonContent(new { Status = status }));
            TempData["Success"] = $"Appointment marked as {status}.";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Cancel(int id)
        {
            var client = GetClient();
            await client.DeleteAsync($"api/appointments/{id}");
            TempData["Success"] = "Appointment cancelled.";
            return RedirectToAction("Index");
        }
    }
}
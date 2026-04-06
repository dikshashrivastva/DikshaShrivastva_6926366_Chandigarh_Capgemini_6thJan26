using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HospitalMVC.Helpers;
using HospitalMVC.Models;

namespace HospitalMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _clientFactory = clientFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JwtToken");
            var client = _clientFactory.CreateClient("HospitalAPI");
            if (!string.IsNullOrEmpty(token))
                ApiHelper.SetAuthToken(client, token);

            int doctors = 0, departments = 0, appointments = 0, bills = 0;

            try
            {
                var deptRes = await client.GetAsync("api/departments");
                if (deptRes.IsSuccessStatusCode)
                {
                    var depts = await ApiHelper.DeserializeAsync<List<DepartmentViewModel>>(deptRes);
                    departments = depts?.Count ?? 0;
                }

                var docRes = await client.GetAsync("api/doctors");
                if (docRes.IsSuccessStatusCode)
                {
                    var docs = await ApiHelper.DeserializeAsync<List<DoctorViewModel>>(docRes);
                    doctors = docs?.Count ?? 0;
                }

                var apptRes = await client.GetAsync("api/appointments");
                if (apptRes.IsSuccessStatusCode)
                {
                    var appts = await ApiHelper.DeserializeAsync<List<AppointmentViewModel>>(apptRes);
                    appointments = appts?.Count ?? 0;
                }

                var billRes = await client.GetAsync("api/bills");
                if (billRes.IsSuccessStatusCode)
                {
                    var billList = await ApiHelper.DeserializeAsync<List<BillViewModel>>(billRes);
                    bills = billList?.Count ?? 0;
                }
            }
            catch { }

            ViewBag.Doctors = doctors;
            ViewBag.Departments = departments;
            ViewBag.Appointments = appointments;
            ViewBag.Bills = bills;

            return View();
        }
    }
}
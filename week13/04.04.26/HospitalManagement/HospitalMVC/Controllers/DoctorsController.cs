using HospitalMVC.Helpers;
using HospitalMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMVC.Controllers
{
    [Authorize]
    public class DoctorsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public DoctorsController(IHttpClientFactory clientFactory)
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

        public async Task<IActionResult> Index(int? departmentId)
        {
            var client = GetClient();
            var url = departmentId.HasValue
                ? $"api/doctors/department/{departmentId}"
                : "api/doctors";
            var response = await client.GetAsync(url);
            var doctors = new List<DoctorViewModel>();
            if (response.IsSuccessStatusCode)
                doctors = await ApiHelper.DeserializeAsync<List<DoctorViewModel>>(response) ?? new();

            var deptRes = await client.GetAsync("api/departments");
            var departments = new List<DepartmentViewModel>();
            if (deptRes.IsSuccessStatusCode)
                departments = await ApiHelper.DeserializeAsync<List<DepartmentViewModel>>(deptRes) ?? new();

            ViewBag.Departments = departments;
            ViewBag.SelectedDept = departmentId;
            return View(doctors);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var client = GetClient();
            var deptRes = await client.GetAsync("api/departments");
            var departments = new List<DepartmentViewModel>();
            if (deptRes.IsSuccessStatusCode)
                departments = await ApiHelper.DeserializeAsync<List<DepartmentViewModel>>(deptRes) ?? new();
            return View(new CreateDoctorViewModel { Departments = departments });
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateDoctorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var client2 = GetClient();
                var deptRes2 = await client2.GetAsync("api/departments");
                if (deptRes2.IsSuccessStatusCode)
                    model.Departments = await ApiHelper.DeserializeAsync<List<DepartmentViewModel>>(deptRes2) ?? new();
                return View(model);
            }
            var client = GetClient();
            var response = await client.PostAsync("api/doctors", ApiHelper.ToJsonContent(new
            {
                model.FullName, model.Email, model.Password,
                model.Specialization, model.ExperienceYears,
                model.Availability, model.DepartmentId
            }));
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Doctor added successfully!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to add doctor. Email may already exist.");
            var deptRes = await client.GetAsync("api/departments");
            if (deptRes.IsSuccessStatusCode)
                model.Departments = await ApiHelper.DeserializeAsync<List<DepartmentViewModel>>(deptRes) ?? new();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var client = GetClient();
            var res = await client.GetAsync($"api/doctors/{id}");
            if (!res.IsSuccessStatusCode) return NotFound();
            var doctor = await ApiHelper.DeserializeAsync<DoctorViewModel>(res);
            var deptRes = await client.GetAsync("api/departments");
            var departments = new List<DepartmentViewModel>();
            if (deptRes.IsSuccessStatusCode)
                departments = await ApiHelper.DeserializeAsync<List<DepartmentViewModel>>(deptRes) ?? new();
            return View(new CreateDoctorViewModel
            {
                FullName = doctor!.FullName, Email = doctor.Email,
                Specialization = doctor.Specialization,
                ExperienceYears = doctor.ExperienceYears,
                Availability = doctor.Availability,
                DepartmentId = doctor.DepartmentId,
                Departments = departments
            });
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, CreateDoctorViewModel model)
        {
            var client = GetClient();
            var response = await client.PutAsync($"api/doctors/{id}", ApiHelper.ToJsonContent(new
            {
                model.Specialization, model.ExperienceYears,
                model.Availability, model.DepartmentId
            }));
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Doctor updated successfully!";
                return RedirectToAction("Index");
            }
            TempData["Error"] = "Failed to update doctor.";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"api/doctors/{id}");
            TempData[response.IsSuccessStatusCode ? "Success" : "Error"] =
                response.IsSuccessStatusCode ? "Doctor removed." : "Failed to delete doctor.";
            return RedirectToAction("Index");
        }
    }
}
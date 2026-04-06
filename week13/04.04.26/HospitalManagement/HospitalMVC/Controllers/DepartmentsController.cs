using HospitalMVC.Helpers;
using HospitalMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMVC.Controllers
{
    [Authorize]
    public class DepartmentsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public DepartmentsController(IHttpClientFactory clientFactory)
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
            var response = await client.GetAsync("api/departments");
            var departments = new List<DepartmentViewModel>();
            if (response.IsSuccessStatusCode)
                departments = await ApiHelper.DeserializeAsync<List<DepartmentViewModel>>(response) ?? new();
            return View(departments);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(DepartmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var client = GetClient();
            var response = await client.PostAsync("api/departments",
                ApiHelper.ToJsonContent(new { model.DepartmentName, model.Description }));
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Department created successfully!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to create department.");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var client = GetClient();
            var response = await client.GetAsync($"api/departments/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();
            var dept = await ApiHelper.DeserializeAsync<DepartmentViewModel>(response);
            return View(dept);
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, DepartmentViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var client = GetClient();
            var response = await client.PutAsync($"api/departments/{id}",
                ApiHelper.ToJsonContent(new { model.DepartmentName, model.Description }));
            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Department updated successfully!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to update department.");
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"api/departments/{id}");
            TempData[response.IsSuccessStatusCode ? "Success" : "Error"] =
                response.IsSuccessStatusCode ? "Department deleted." : "Failed to delete department.";
            return RedirectToAction("Index");
        }
    }
}
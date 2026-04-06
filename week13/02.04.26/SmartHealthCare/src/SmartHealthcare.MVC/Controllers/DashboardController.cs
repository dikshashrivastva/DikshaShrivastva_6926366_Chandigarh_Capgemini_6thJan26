using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.MVC.Services;
using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.MVC.Controllers;

public class DashboardController : Controller
{
    private readonly IApiService _apiService;

    public DashboardController(IApiService apiService)
    {
        _apiService = apiService;
    }

    public async Task<IActionResult> Index()
    {
        var token = HttpContext.Session.GetString("Token");
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.Role = HttpContext.Session.GetString("Role");
        ViewBag.FullName = HttpContext.Session.GetString("FullName");

        if ((ViewBag.Role as string) == "Admin")
        {
            // Fetch counts in parallel for speed
            var usersTask        = _apiService.GetAsync<PagedResult<UserDTO>>("admin/users?pageNumber=1&pageSize=1", token);
            var doctorsTask      = _apiService.GetAsync<PagedResult<DoctorDTO>>("doctors?pageNumber=1&pageSize=1", token);
            var patientsTask     = _apiService.GetAsync<PagedResult<PatientDTO>>("patients?pageNumber=1&pageSize=1", token);
            var appointmentsTask = _apiService.GetAsync<PagedResult<AppointmentDTO>>("appointments?pageNumber=1&pageSize=1", token);

            await Task.WhenAll(usersTask, doctorsTask, patientsTask, appointmentsTask);

            ViewBag.TotalUsers        = (await usersTask)?.TotalCount ?? 0;
            ViewBag.TotalDoctors      = (await doctorsTask)?.TotalCount ?? 0;
            ViewBag.TotalPatients     = (await patientsTask)?.TotalCount ?? 0;
            ViewBag.TotalAppointments = (await appointmentsTask)?.TotalCount ?? 0;
        }

        return View();
    }
}
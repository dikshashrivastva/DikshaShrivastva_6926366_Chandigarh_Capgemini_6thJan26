using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.MVC.Services;
using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.MVC.Controllers;

public class BillingController : Controller
{
    private readonly IApiService _apiService;
    private readonly ILogger<BillingController> _logger;

    public BillingController(IApiService apiService, ILogger<BillingController> logger)
    {
        _apiService = apiService;
        _logger = logger;
    }

    private string? GetToken() => HttpContext.Session.GetString("Token");
    private string? GetRole()  => HttpContext.Session.GetString("Role");

    public async Task<IActionResult> Index()
    {
        var token = GetToken();
        if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Account");

        var role = GetRole();
        PagedResult<BillDTO>? result = null;

        if (role == "Patient")
            result = await _apiService.GetAsync<PagedResult<BillDTO>>("bills/my-bills?pageNumber=1&pageSize=50", token);
        else if (role == "Admin" || role == "Doctor")
            result = await _apiService.GetAsync<PagedResult<BillDTO>>("bills?pageNumber=1&pageSize=50", token);

        ViewBag.Role = role;
        return View(result?.Items ?? Enumerable.Empty<BillDTO>());
    }

    public async Task<IActionResult> Details(int id)
    {
        var token = GetToken();
        if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Account");

        var bill = await _apiService.GetAsync<BillDTO>($"bills/{id}", token);
        if (bill == null) return NotFound();

        ViewBag.Role = GetRole();
        return View(bill);
    }

    [HttpGet]
    public async Task<IActionResult> Create(int appointmentId)
    {
        var token = GetToken();
        if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Account");

        var role = GetRole();
        if (role != "Admin" && role != "Doctor") return Forbid();

        var dto = new CreateBillDTO { AppointmentId = appointmentId };
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBillDTO dto)
    {
        var token = GetToken();
        if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Account");

        if (!ModelState.IsValid) return View(dto);

        var result = await _apiService.PostAsync<BillDTO>("bills", dto, token);
        if (result == null)
        {
            ModelState.AddModelError(string.Empty, "Failed to create bill. A bill may already exist for this appointment.");
            return View(dto);
        }

        TempData["Success"] = "Bill created successfully!";
        return RedirectToAction(nameof(Details), new { id = result.Id });
    }

    [HttpPost]
    public async Task<IActionResult> MarkAsPaid(int id)
    {
        var token = GetToken();
        if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Account");

        var dto = new UpdateBillPaymentDTO { PaymentStatus = "Paid" };
        await _apiService.PatchAsync<object>($"bills/{id}/payment-status", dto, token);

        TempData["Success"] = "Payment status updated!";
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var token = GetToken();
        if (string.IsNullOrEmpty(token)) return RedirectToAction("Login", "Account");

        await _apiService.DeleteAsync($"bills/{id}", token);
        TempData["Success"] = "Bill deleted.";
        return RedirectToAction(nameof(Index));
    }
}
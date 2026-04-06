using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHealthcare.API.Services.Interfaces;
using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BillsController : ControllerBase
{
    private readonly IBillService _service;
    private readonly IPatientService _patientService;
    private readonly ILogger<BillsController> _logger;

    public BillsController(IBillService service, IPatientService patientService, ILogger<BillsController> logger)
    {
        _service = service;
        _patientService = patientService;
        _logger = logger;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        => Ok(await _service.GetAllAsync(pageNumber, pageSize));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var bill = await _service.GetByIdAsync(id);
        if (bill == null) return NotFound(new ErrorResponseDTO { Message = "Bill not found", StatusCode = 404 });
        return Ok(bill);
    }

    [HttpGet("appointment/{appointmentId:int}")]
    public async Task<IActionResult> GetByAppointmentId(int appointmentId)
    {
        var bill = await _service.GetByAppointmentIdAsync(appointmentId);
        if (bill == null) return NotFound(new ErrorResponseDTO { Message = "Bill not found for this appointment", StatusCode = 404 });
        return Ok(bill);
    }

    [HttpGet("my-bills")]
    [Authorize(Roles = "Patient")]
    public async Task<IActionResult> GetMyBills([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
        var patient = await _patientService.GetByUserIdAsync(userId);
        if (patient == null) return BadRequest(new ErrorResponseDTO { Message = "Patient profile not found", StatusCode = 400 });

        var result = await _service.GetByPatientIdAsync(patient.Id, pageNumber, pageSize);
        return Ok(result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Doctor")]
    public async Task<IActionResult> Create([FromBody] CreateBillDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var result = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPatch("{id:int}/payment-status")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdatePaymentStatus(int id, [FromBody] UpdateBillPaymentDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var success = await _service.UpdatePaymentStatusAsync(id, dto);
        if (!success) return NotFound(new ErrorResponseDTO { Message = "Bill not found", StatusCode = 404 });
        return Ok(new { message = "Payment status updated" });
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success) return NotFound(new ErrorResponseDTO { Message = "Bill not found", StatusCode = 404 });
        return Ok(new { message = "Bill deleted" });
    }
}
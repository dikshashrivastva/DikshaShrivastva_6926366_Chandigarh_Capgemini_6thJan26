using AutoMapper;
using HospitalAPI.DTOs;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BillsController : ControllerBase
    {
        private readonly IBillRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<BillsController> _logger;

        public BillsController(IBillRepository repo, IMapper mapper,
            ILogger<BillsController> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var bills = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<BillDTO>>(bills));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bill = await _repo.GetByIdAsync(id);
            if (bill == null) return NotFound(new { Message = "Bill not found." });
            return Ok(_mapper.Map<BillDTO>(bill));
        }

        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetByAppointment(int appointmentId)
        {
            var bill = await _repo.GetByAppointmentIdAsync(appointmentId);
            if (bill == null) return NotFound(new { Message = "No bill for this appointment." });
            return Ok(_mapper.Map<BillDTO>(bill));
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> Create([FromBody] CreateBillDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _repo.GetByAppointmentIdAsync(dto.AppointmentId);
            if (existing != null)
                return BadRequest(new { Message = "Bill already exists for this appointment." });

            var bill = _mapper.Map<Bill>(dto);
            var created = await _repo.CreateAsync(bill);
            _logger.LogInformation("Bill created for AppointmentId: {Id}", dto.AppointmentId);

            var result = await _repo.GetByIdAsync(created.BillId);
            return CreatedAtAction(nameof(GetById), new { id = created.BillId },
                _mapper.Map<BillDTO>(result));
        }

        [HttpPut("{id}/payment")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdatePaymentStatus(int id, [FromBody] UpdateBillStatusDTO dto)
        {
            var bill = await _repo.GetByIdAsync(id);
            if (bill == null) return NotFound(new { Message = "Bill not found." });

            bill.PaymentStatus = dto.PaymentStatus;
            await _repo.UpdateAsync(bill);
            return Ok(new { Message = "Payment status updated successfully." });
        }
    }
}
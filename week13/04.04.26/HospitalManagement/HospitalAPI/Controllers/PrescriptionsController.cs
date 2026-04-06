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
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<PrescriptionsController> _logger;

        public PrescriptionsController(IPrescriptionRepository repo, IMapper mapper,
            ILogger<PrescriptionsController> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PrescriptionDTO>>(list));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var prescription = await _repo.GetByIdAsync(id);
            if (prescription == null) return NotFound(new { Message = "Prescription not found." });
            return Ok(_mapper.Map<PrescriptionDTO>(prescription));
        }

        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetByAppointment(int appointmentId)
        {
            var prescription = await _repo.GetByAppointmentIdAsync(appointmentId);
            if (prescription == null) return NotFound(new { Message = "No prescription for this appointment." });
            return Ok(_mapper.Map<PrescriptionDTO>(prescription));
        }

        [HttpPost]
        [Authorize(Roles = "Doctor,Admin")]
        public async Task<IActionResult> Create([FromBody] CreatePrescriptionDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _repo.GetByAppointmentIdAsync(dto.AppointmentId);
            if (existing != null)
                return BadRequest(new { Message = "Prescription already exists for this appointment." });

            var prescription = _mapper.Map<Prescription>(dto);
            var created = await _repo.CreateAsync(prescription);
            _logger.LogInformation("Prescription created for AppointmentId: {Id}", dto.AppointmentId);

            return CreatedAtAction(nameof(GetById), new { id = created.PrescriptionId },
                _mapper.Map<PrescriptionDTO>(created));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Doctor,Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] CreatePrescriptionDTO dto)
        {
            var prescription = await _repo.GetByIdAsync(id);
            if (prescription == null) return NotFound(new { Message = "Prescription not found." });

            prescription.Diagnosis = dto.Diagnosis;
            prescription.Medicines = dto.Medicines;
            prescription.Notes = dto.Notes;

            var updated = await _repo.UpdateAsync(prescription);
            return Ok(_mapper.Map<PrescriptionDTO>(updated));
        }
    }
}
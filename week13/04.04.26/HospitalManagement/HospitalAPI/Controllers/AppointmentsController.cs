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
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<AppointmentsController> _logger;

        public AppointmentsController(IAppointmentRepository repo, IMapper mapper,
            ILogger<AppointmentsController> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> GetAll()
        {
            var appointments = await _repo.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<AppointmentDTO>>(appointments));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var appointment = await _repo.GetByIdAsync(id);
            if (appointment == null) return NotFound(new { Message = "Appointment not found." });
            return Ok(_mapper.Map<AppointmentDTO>(appointment));
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetByPatient(int patientId)
        {
            var appointments = await _repo.GetByPatientIdAsync(patientId);
            return Ok(_mapper.Map<IEnumerable<AppointmentDTO>>(appointments));
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetByDoctor(int doctorId)
        {
            var appointments = await _repo.GetByDoctorIdAsync(doctorId);
            return Ok(_mapper.Map<IEnumerable<AppointmentDTO>>(appointments));
        }

        [HttpPost]
        [Authorize(Roles = "Patient,Admin")]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var appointment = _mapper.Map<Appointment>(dto);
            var created = await _repo.CreateAsync(appointment);
            _logger.LogInformation("Appointment created for PatientId: {Id}", dto.PatientId);

            var result = await _repo.GetByIdAsync(created.AppointmentId);
            return CreatedAtAction(nameof(GetById), new { id = created.AppointmentId },
                _mapper.Map<AppointmentDTO>(result));
        }

        [HttpPut("{id}/status")]
        [Authorize(Roles = "Admin,Doctor")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] UpdateAppointmentStatusDTO dto)
        {
            var appointment = await _repo.GetByIdAsync(id);
            if (appointment == null) return NotFound(new { Message = "Appointment not found." });

            appointment.Status = dto.Status;
            await _repo.UpdateAsync(appointment);
            return Ok(new { Message = "Status updated successfully." });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Patient")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) return NotFound(new { Message = "Appointment not found." });
            return Ok(new { Message = "Appointment cancelled successfully." });
        }
    }
}
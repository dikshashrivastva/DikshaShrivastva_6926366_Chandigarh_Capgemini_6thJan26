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
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorRepository _doctorRepo;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<DoctorsController> _logger;

        public DoctorsController(IDoctorRepository doctorRepo, IUserRepository userRepo,
            IMapper mapper, ILogger<DoctorsController> logger)
        {
            _doctorRepo = doctorRepo;
            _userRepo = userRepo;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var doctors = await _doctorRepo.GetAllAsync();
            var result = _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor == null) return NotFound(new { Message = "Doctor not found." });
            return Ok(_mapper.Map<DoctorDTO>(doctor));
        }

        [HttpGet("department/{departmentId}")]
        public async Task<IActionResult> GetByDepartment(int departmentId)
        {
            var doctors = await _doctorRepo.GetByDepartmentAsync(departmentId);
            var result = _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateDoctorDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _userRepo.ExistsAsync(dto.Email))
                return BadRequest(new { Message = "Email already registered." });

            // Create user account for doctor
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Doctor",
                CreatedAt = DateTime.Now
            };
            var createdUser = await _userRepo.CreateAsync(user);

            // Create doctor profile
            var doctor = new Doctor
            {
                UserId = createdUser.UserId,
                DepartmentId = dto.DepartmentId,
                Specialization = dto.Specialization,
                ExperienceYears = dto.ExperienceYears,
                Availability = dto.Availability
            };
            var createdDoctor = await _doctorRepo.CreateAsync(doctor);
            _logger.LogInformation("Doctor created: {Name}", dto.FullName);

            var result = await _doctorRepo.GetByIdAsync(createdDoctor.DoctorId);
            return CreatedAtAction(nameof(GetById), new { id = createdDoctor.DoctorId },
                _mapper.Map<DoctorDTO>(result));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDoctorDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var doctor = await _doctorRepo.GetByIdAsync(id);
            if (doctor == null) return NotFound(new { Message = "Doctor not found." });

            doctor.Specialization = dto.Specialization;
            doctor.ExperienceYears = dto.ExperienceYears;
            doctor.Availability = dto.Availability;
            doctor.DepartmentId = dto.DepartmentId;

            var updated = await _doctorRepo.UpdateAsync(doctor);
            var result = await _doctorRepo.GetByIdAsync(updated.DoctorId);
            return Ok(_mapper.Map<DoctorDTO>(result));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _doctorRepo.DeleteAsync(id);
            if (!deleted) return NotFound(new { Message = "Doctor not found." });
            return Ok(new { Message = "Doctor deleted successfully." });
        }
    }
}
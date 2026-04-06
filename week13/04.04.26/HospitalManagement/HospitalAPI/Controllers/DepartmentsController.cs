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
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentsController> _logger;

        public DepartmentsController(IDepartmentRepository repo, IMapper mapper,
            ILogger<DepartmentsController> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _repo.GetAllAsync();
            var result = _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _repo.GetByIdAsync(id);
            if (department == null) return NotFound(new { Message = "Department not found." });
            return Ok(_mapper.Map<DepartmentDTO>(department));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateDepartmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var department = _mapper.Map<Department>(dto);
            var created = await _repo.CreateAsync(department);
            _logger.LogInformation("Department created: {Name}", dto.DepartmentName);
            return CreatedAtAction(nameof(GetById), new { id = created.DepartmentId },
                _mapper.Map<DepartmentDTO>(created));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateDepartmentDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound(new { Message = "Department not found." });

            existing.DepartmentName = dto.DepartmentName;
            existing.Description = dto.Description;

            var updated = await _repo.UpdateAsync(existing);
            return Ok(_mapper.Map<DepartmentDTO>(updated));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repo.DeleteAsync(id);
            if (!deleted) return NotFound(new { Message = "Department not found." });
            return Ok(new { Message = "Department deleted successfully." });
        }
    }
}
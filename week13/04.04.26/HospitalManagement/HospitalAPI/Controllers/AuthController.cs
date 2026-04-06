using AutoMapper;
using BCrypt.Net;
using HospitalAPI.DTOs;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using HospitalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserRepository userRepo, IJwtService jwtService,
            IMapper mapper, ILogger<AuthController> logger)
        {
            _userRepo = userRepo;
            _jwtService = jwtService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (await _userRepo.ExistsAsync(dto.Email))
                return BadRequest(new { Message = "Email already registered." });

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role,
                CreatedAt = DateTime.Now
            };

            var created = await _userRepo.CreateAsync(user);
            _logger.LogInformation("New user registered: {Email}", dto.Email);

            return Ok(new { Message = "Registration successful.", UserId = created.UserId });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userRepo.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized(new { Message = "Invalid email or password." });

            var token = _jwtService.GenerateToken(user);
            _logger.LogInformation("User logged in: {Email}", dto.Email);

            return Ok(new AuthResponseDTO
            {
                Token = token,
                Role = user.Role,
                FullName = user.FullName,
                UserId = user.UserId
            });
        }

        [HttpGet("users")]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepo.GetAllAsync();
            var result = _mapper.Map<IEnumerable<UserResponseDTO>>(users);
            return Ok(result);
        }

        [HttpDelete("users/{id}")]
        [Microsoft.AspNetCore.Authorization.Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userRepo.DeleteAsync(id);
            if (!deleted) return NotFound(new { Message = "User not found." });
            return Ok(new { Message = "User deleted successfully." });
        }
    }
}
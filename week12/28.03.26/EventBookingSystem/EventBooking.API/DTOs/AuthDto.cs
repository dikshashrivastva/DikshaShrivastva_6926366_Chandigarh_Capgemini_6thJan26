using System.ComponentModel.DataAnnotations;

namespace EventBooking.API.DTOs
{
    // For Register
    public class RegisterDto
    {
        [Required] 
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress] 
        public string Email { get; set; } = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")] 
        public string Password { get; set; } = string.Empty;
    }

    // For Login
    public class LoginDto
    {
        [Required] 
        public string Email { get; set; } = string.Empty;

        [Required] 
        public string Password { get; set; } = string.Empty;
    }

    
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
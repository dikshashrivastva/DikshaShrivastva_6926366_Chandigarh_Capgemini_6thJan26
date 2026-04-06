using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty; // Admin, Doctor, Patient

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public Doctor? Doctor { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
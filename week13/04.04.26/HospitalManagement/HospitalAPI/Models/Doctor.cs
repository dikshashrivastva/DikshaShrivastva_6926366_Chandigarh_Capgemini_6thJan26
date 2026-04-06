using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public int UserId { get; set; }
        public int DepartmentId { get; set; }

        [MaxLength(100)]
        public string? Specialization { get; set; }

        public int ExperienceYears { get; set; }

        [MaxLength(100)]
        public string? Availability { get; set; }

        // Navigation
        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
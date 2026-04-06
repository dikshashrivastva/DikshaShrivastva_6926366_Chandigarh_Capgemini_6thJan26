using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class DoctorDTO
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public string? Availability { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }

    public class CreateDoctorDTO
    {
        [Required] public string FullName { get; set; } = string.Empty;
        [Required, EmailAddress] public string Email { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
        public string? Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public string? Availability { get; set; }
        [Required] public int DepartmentId { get; set; }
    }

    public class UpdateDoctorDTO
    {
        public string? Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public string? Availability { get; set; }
        public int DepartmentId { get; set; }
    }
}
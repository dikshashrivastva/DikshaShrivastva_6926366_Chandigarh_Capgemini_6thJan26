using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int DoctorCount { get; set; }
    }

    public class CreateDepartmentDTO
    {
        [Required, MaxLength(100)] public string DepartmentName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
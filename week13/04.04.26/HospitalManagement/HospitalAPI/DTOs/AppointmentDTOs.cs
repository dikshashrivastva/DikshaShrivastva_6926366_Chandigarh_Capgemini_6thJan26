using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class CreateAppointmentDTO
    {
        [Required] public int PatientId { get; set; }
        [Required] public int DoctorId { get; set; }
        [Required] public DateTime AppointmentDate { get; set; }
    }

    public class UpdateAppointmentStatusDTO
    {
        [Required] public string Status { get; set; } = string.Empty;
    }
}
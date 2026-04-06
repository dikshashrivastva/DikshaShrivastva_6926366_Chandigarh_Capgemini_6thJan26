using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class PrescriptionDTO
    {
        public int PrescriptionId { get; set; }
        public int AppointmentId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public string? Diagnosis { get; set; }
        public string? Medicines { get; set; }
        public string? Notes { get; set; }
    }

    public class CreatePrescriptionDTO
    {
        [Required] public int AppointmentId { get; set; }
        public string? Diagnosis { get; set; }
        public string? Medicines { get; set; }
        public string? Notes { get; set; }
    }
}
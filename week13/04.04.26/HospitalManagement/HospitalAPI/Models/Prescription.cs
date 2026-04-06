using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Prescription
    {
        [Key]
        public int PrescriptionId { get; set; }

        public int AppointmentId { get; set; }

        [MaxLength(255)]
        public string? Diagnosis { get; set; }

        public string? Medicines { get; set; }

        [MaxLength(255)]
        public string? Notes { get; set; }

        // Navigation
        [ForeignKey("AppointmentId")]
        public Appointment? Appointment { get; set; }
    }
}
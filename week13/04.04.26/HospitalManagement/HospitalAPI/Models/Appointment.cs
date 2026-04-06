using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        [MaxLength(20)]
        public string Status { get; set; } = "Booked"; // Booked, Completed, Cancelled

        // Navigation
        [ForeignKey("PatientId")]
        public User? Patient { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        public Prescription? Prescription { get; set; }
        public Bill? Bill { get; set; }
    }
}
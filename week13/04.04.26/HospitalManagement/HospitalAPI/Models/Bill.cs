using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }

        public int AppointmentId { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal ConsultationFee { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal MedicineCharges { get; set; }

        [NotMapped]
        public decimal TotalAmount => ConsultationFee + MedicineCharges;

        [MaxLength(20)]
        public string PaymentStatus { get; set; } = "Unpaid";

        // Navigation
        [ForeignKey("AppointmentId")]
        public Appointment? Appointment { get; set; }
    }
}
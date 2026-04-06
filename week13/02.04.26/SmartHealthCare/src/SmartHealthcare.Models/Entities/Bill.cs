using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmartHealthcare.Models.Entities;

public class Bill
{
    public int Id { get; set; }

    [Required]
    public int AppointmentId { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal ConsultationFee { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal MedicineCharges { get; set; } = 0;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    [Required, MaxLength(20)]
    public string PaymentStatus { get; set; } = "Unpaid"; // Paid / Unpaid

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Appointment Appointment { get; set; } = null!;
}
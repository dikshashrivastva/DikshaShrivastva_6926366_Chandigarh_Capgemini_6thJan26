using System.ComponentModel.DataAnnotations;

namespace SmartHealthcare.Models.DTOs;

public class BillDTO
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public string PatientName { get; set; } = string.Empty;
    public string DoctorName { get; set; } = string.Empty;
    public DateTime AppointmentDate { get; set; }
    public decimal ConsultationFee { get; set; }
    public decimal MedicineCharges { get; set; }
    public decimal TotalAmount { get; set; }
    public string PaymentStatus { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}

public class CreateBillDTO
{
    [Required]
    public int AppointmentId { get; set; }

    [Required, Range(0, 100000)]
    public decimal ConsultationFee { get; set; }

    [Range(0, 100000)]
    public decimal MedicineCharges { get; set; } = 0;
}

public class UpdateBillPaymentDTO
{
    [Required]
    [RegularExpression("Paid|Unpaid", ErrorMessage = "Status must be Paid or Unpaid")]
    public string PaymentStatus { get; set; } = string.Empty;
}
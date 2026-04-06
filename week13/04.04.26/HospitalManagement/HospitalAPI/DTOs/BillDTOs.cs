using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.DTOs
{
    public class BillDTO
    {
        public int BillId { get; set; }
        public int AppointmentId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public decimal ConsultationFee { get; set; }
        public decimal MedicineCharges { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
    }

    public class CreateBillDTO
    {
        [Required] public int AppointmentId { get; set; }
        [Required] public decimal ConsultationFee { get; set; }
        [Required] public decimal MedicineCharges { get; set; }
        public string PaymentStatus { get; set; } = "Unpaid";
    }

    public class UpdateBillStatusDTO
    {
        [Required] public string PaymentStatus { get; set; } = string.Empty;
    }
}
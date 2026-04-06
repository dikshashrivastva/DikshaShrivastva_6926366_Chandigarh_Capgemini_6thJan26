using SmartHealthcare.Models.DTOs;

namespace SmartHealthcare.API.Services.Interfaces;

public interface IBillService
{
    Task<PagedResult<BillDTO>> GetAllAsync(int page, int pageSize);
    Task<BillDTO?> GetByIdAsync(int id);
    Task<BillDTO?> GetByAppointmentIdAsync(int appointmentId);
    Task<PagedResult<BillDTO>> GetByPatientIdAsync(int patientId, int page, int pageSize);
    Task<BillDTO> CreateAsync(CreateBillDTO dto);
    Task<bool> UpdatePaymentStatusAsync(int id, UpdateBillPaymentDTO dto);
    Task<bool> DeleteAsync(int id);
}
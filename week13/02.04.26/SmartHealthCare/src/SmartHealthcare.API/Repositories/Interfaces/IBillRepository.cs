using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Repositories.Interfaces;

public interface IBillRepository : IGenericRepository<Bill>
{
    Task<Bill?> GetWithDetailsAsync(int id);
    Task<Bill?> GetByAppointmentIdAsync(int appointmentId);
    Task<IEnumerable<Bill>> GetAllWithDetailsAsync(int page, int pageSize);
    Task<IEnumerable<Bill>> GetByPatientIdAsync(int patientId, int page, int pageSize);
    Task<int> CountAsync();
    Task<int> CountByPatientAsync(int patientId);
}
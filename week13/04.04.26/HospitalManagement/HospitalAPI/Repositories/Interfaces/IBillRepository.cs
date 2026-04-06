using HospitalAPI.Models;

namespace HospitalAPI.Repositories.Interfaces
{
    public interface IBillRepository
    {
        Task<IEnumerable<Bill>> GetAllAsync();
        Task<Bill?> GetByIdAsync(int id);
        Task<Bill?> GetByAppointmentIdAsync(int appointmentId);
        Task<Bill> CreateAsync(Bill bill);
        Task<Bill> UpdateAsync(Bill bill);
    }
}
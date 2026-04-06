using HospitalAPI.Models;

namespace HospitalAPI.Repositories.Interfaces
{
    public interface IPrescriptionRepository
    {
        Task<IEnumerable<Prescription>> GetAllAsync();
        Task<Prescription?> GetByIdAsync(int id);
        Task<Prescription?> GetByAppointmentIdAsync(int appointmentId);
        Task<Prescription> CreateAsync(Prescription prescription);
        Task<Prescription> UpdateAsync(Prescription prescription);
    }
}

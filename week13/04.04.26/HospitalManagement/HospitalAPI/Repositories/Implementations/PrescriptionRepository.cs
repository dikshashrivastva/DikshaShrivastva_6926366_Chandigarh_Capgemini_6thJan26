using HospitalAPI.Data;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories.Implementations
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly HospitalDbContext _context;

        public PrescriptionRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prescription>> GetAllAsync() =>
            await _context.Prescriptions
                .Include(p => p.Appointment).ThenInclude(a => a!.Patient)
                .Include(p => p.Appointment).ThenInclude(a => a!.Doctor).ThenInclude(d => d!.User)
                .ToListAsync();

        public async Task<Prescription?> GetByIdAsync(int id) =>
            await _context.Prescriptions
                .Include(p => p.Appointment).ThenInclude(a => a!.Patient)
                .Include(p => p.Appointment).ThenInclude(a => a!.Doctor).ThenInclude(d => d!.User)
                .FirstOrDefaultAsync(p => p.PrescriptionId == id);

        public async Task<Prescription?> GetByAppointmentIdAsync(int appointmentId) =>
            await _context.Prescriptions
                .Include(p => p.Appointment)
                .FirstOrDefaultAsync(p => p.AppointmentId == appointmentId);

        public async Task<Prescription> CreateAsync(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }

        public async Task<Prescription> UpdateAsync(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            await _context.SaveChangesAsync();
            return prescription;
        }
    }
}
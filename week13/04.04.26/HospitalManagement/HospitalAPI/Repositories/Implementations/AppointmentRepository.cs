using HospitalAPI.Data;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories.Implementations
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HospitalDbContext _context;

        public AppointmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync() =>
            await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor).ThenInclude(d => d!.Department)
                .Include(a => a.Doctor).ThenInclude(d => d!.User)
                .ToListAsync();

        public async Task<Appointment?> GetByIdAsync(int id) =>
            await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor).ThenInclude(d => d!.Department)
                .Include(a => a.Doctor).ThenInclude(d => d!.User)
                .Include(a => a.Prescription)
                .Include(a => a.Bill)
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

        public async Task<IEnumerable<Appointment>> GetByPatientIdAsync(int patientId) =>
            await _context.Appointments
                .Include(a => a.Doctor).ThenInclude(d => d!.User)
                .Include(a => a.Doctor).ThenInclude(d => d!.Department)
                .Where(a => a.PatientId == patientId)
                .ToListAsync();

        public async Task<IEnumerable<Appointment>> GetByDoctorIdAsync(int doctorId) =>
            await _context.Appointments
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == doctorId)
                .ToListAsync();

        public async Task<Appointment> CreateAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null) return false;
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
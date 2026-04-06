using Microsoft.EntityFrameworkCore;
using SmartHealthcare.API.Data;
using SmartHealthcare.API.Repositories.Interfaces;
using SmartHealthcare.Models.Entities;

namespace SmartHealthcare.API.Repositories;

public class BillRepository : GenericRepository<Bill>, IBillRepository
{
    public BillRepository(ApplicationDbContext context) : base(context) { }

    public async Task<Bill?> GetWithDetailsAsync(int id)
        => await _dbSet
            .Include(b => b.Appointment).ThenInclude(a => a.Patient).ThenInclude(p => p.User)
            .Include(b => b.Appointment).ThenInclude(a => a.Doctor).ThenInclude(d => d.User)
            .FirstOrDefaultAsync(b => b.Id == id);

    public async Task<Bill?> GetByAppointmentIdAsync(int appointmentId)
        => await _dbSet
            .Include(b => b.Appointment).ThenInclude(a => a.Patient).ThenInclude(p => p.User)
            .Include(b => b.Appointment).ThenInclude(a => a.Doctor).ThenInclude(d => d.User)
            .FirstOrDefaultAsync(b => b.AppointmentId == appointmentId);

    public async Task<IEnumerable<Bill>> GetAllWithDetailsAsync(int page, int pageSize)
        => await _dbSet
            .Include(b => b.Appointment).ThenInclude(a => a.Patient).ThenInclude(p => p.User)
            .Include(b => b.Appointment).ThenInclude(a => a.Doctor).ThenInclude(d => d.User)
            .OrderByDescending(b => b.CreatedAt)
            .Skip((page - 1) * pageSize).Take(pageSize)
            .ToListAsync();

    public async Task<IEnumerable<Bill>> GetByPatientIdAsync(int patientId, int page, int pageSize)
        => await _dbSet
            .Include(b => b.Appointment).ThenInclude(a => a.Patient).ThenInclude(p => p.User)
            .Include(b => b.Appointment).ThenInclude(a => a.Doctor).ThenInclude(d => d.User)
            .Where(b => b.Appointment.Patient.Id == patientId)
            .OrderByDescending(b => b.CreatedAt)
            .Skip((page - 1) * pageSize).Take(pageSize)
            .ToListAsync();

    public async Task<int> CountAsync()
        => await _dbSet.CountAsync();

    public async Task<int> CountByPatientAsync(int patientId)
        => await _dbSet.CountAsync(b => b.Appointment.Patient.Id == patientId);
}
using HospitalAPI.Data;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories.Implementations
{
    public class BillRepository : IBillRepository
    {
        private readonly HospitalDbContext _context;

        public BillRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bill>> GetAllAsync() =>
            await _context.Bills
                .Include(b => b.Appointment).ThenInclude(a => a!.Patient)
                .Include(b => b.Appointment).ThenInclude(a => a!.Doctor).ThenInclude(d => d!.User)
                .ToListAsync();

        public async Task<Bill?> GetByIdAsync(int id) =>
            await _context.Bills
                .Include(b => b.Appointment).ThenInclude(a => a!.Patient)
                .Include(b => b.Appointment).ThenInclude(a => a!.Doctor).ThenInclude(d => d!.User)
                .FirstOrDefaultAsync(b => b.BillId == id);

        public async Task<Bill?> GetByAppointmentIdAsync(int appointmentId) =>
            await _context.Bills.FirstOrDefaultAsync(b => b.AppointmentId == appointmentId);

        public async Task<Bill> CreateAsync(Bill bill)
        {
            _context.Bills.Add(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<Bill> UpdateAsync(Bill bill)
        {
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
            return bill;
        }
    }
}
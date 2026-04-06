using HospitalAPI.Data;
using HospitalAPI.Models;
using HospitalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repositories.Implementations
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HospitalDbContext _context;

        public DepartmentRepository(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllAsync() =>
            await _context.Departments.Include(d => d.Doctors).ToListAsync();

        public async Task<Department?> GetByIdAsync(int id) =>
            await _context.Departments.Include(d => d.Doctors).FirstOrDefaultAsync(d => d.DepartmentId == id);

        public async Task<Department> CreateAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return false;
            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
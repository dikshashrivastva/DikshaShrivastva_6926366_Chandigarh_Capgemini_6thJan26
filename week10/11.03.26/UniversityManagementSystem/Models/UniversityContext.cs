using Microsoft.EntityFrameworkCore;

namespace UniversityManagementSystem.Models
{
	public class UniversityContext : DbContext
	{
		public UniversityContext(DbContextOptions<UniversityContext> options)
			: base(options)
		{
		}

		public DbSet<Student> Students { get; set; }

		public DbSet<Course> Courses { get; set; }

		public DbSet<Instructor> Instructors { get; set; }

		public DbSet<Department> Departments { get; set; }

		public DbSet<Enrollment> Enrollments { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Department>()
				.HasMany(d => d.Instructors)
				.WithOne(i => i.Department)
				.HasForeignKey(i => i.DepartmentId);

			modelBuilder.Entity<Instructor>()
				.HasMany(i => i.Courses)
				.WithOne(c => c.Instructor)
				.HasForeignKey(c => c.InstructorId);

			modelBuilder.Entity<Student>()
				.HasMany(s => s.Enrollments)
				.WithOne(e => e.Student)
				.HasForeignKey(e => e.StudentId);

			modelBuilder.Entity<Course>()
				.HasMany(c => c.Enrollments)
				.WithOne(e => e.Course)
				.HasForeignKey(e => e.CourseId);
		}
	}
}
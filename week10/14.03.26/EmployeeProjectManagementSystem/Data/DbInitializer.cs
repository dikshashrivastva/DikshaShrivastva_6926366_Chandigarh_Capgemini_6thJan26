using EmployeeProjectManagementSystem.Models;

namespace EmployeeProjectManagementSystem.Data
{
	public class DbInitializer
	{
		public static void Initialize(ApplicationDbContext context)
		{
			if (context.Departments.Any())
				return;

			var departments = new Department[]
			{
				new Department{Name="IT"},
				new Department{Name="HR"},
				new Department{Name="Finance"}
			};

			context.Departments.AddRange(departments);
			context.SaveChanges();


			var employees = new Employee[]
			{
				new Employee{Name="Amit",DepartmentId=1},
				new Employee{Name="Neha",DepartmentId=2},
				new Employee{Name="Rahul",DepartmentId=1}
			};

			context.Employees.AddRange(employees);
			context.SaveChanges();


			var projects = new Project[]
			{
				new Project{Title="Banking App"},
				new Project{Title="ECommerce Website"},
				new Project{Title="Hospital System"}
			};

			context.Projects.AddRange(projects);
			context.SaveChanges();


			var employeeProjects = new EmployeeProject[]
			{
				new EmployeeProject{EmployeeId=1,ProjectId=1,AssignedDate=DateTime.Now},
				new EmployeeProject{EmployeeId=1,ProjectId=2,AssignedDate=DateTime.Now},
				new EmployeeProject{EmployeeId=2,ProjectId=3,AssignedDate=DateTime.Now},
				new EmployeeProject{EmployeeId=3,ProjectId=1,AssignedDate=DateTime.Now}
			};

			context.EmployeeProjects.AddRange(employeeProjects);
			context.SaveChanges();
		}
	}
}

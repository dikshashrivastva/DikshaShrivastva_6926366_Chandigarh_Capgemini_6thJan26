using Microsoft.AspNetCore.Mvc;
using EmployeeProjectManagementSystem.Data;
using EmployeeProjectManagementSystem.Models;

namespace EmployeeProjectManagementSystem.Controllers
{
	public class DepartmentsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public DepartmentsController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var departments = _context.Departments.ToList();
			return View(departments);
		}
	}
}
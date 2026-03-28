using Microsoft.EntityFrameworkCore;
using EmployeeProjectManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProjectManagementSystem.Controllers
{
	public class DashboardController : Controller
	{
		private readonly ApplicationDbContext _context;

		public DashboardController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var projects = _context.Projects
				.Include(p => p.EmployeeProjects)
				.ThenInclude(ep => ep.Employee)
				.ThenInclude(e => e.Department)
				.ToList();

			return View(projects);
		}
	}
}

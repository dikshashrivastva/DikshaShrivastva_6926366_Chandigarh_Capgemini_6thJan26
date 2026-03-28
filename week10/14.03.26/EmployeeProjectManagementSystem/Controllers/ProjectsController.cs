using EmployeeProjectManagementSystem.Data;
using EmployeeProjectManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProjectManagementSystem.Controllers
{
	public class ProjectsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ProjectsController(ApplicationDbContext context)
		{
			_context = context;
		}

		// READ (Index)
		public IActionResult Index()
		{
			var projects = _context.Projects
				.Include(p => p.EmployeeProjects)
				.ThenInclude(ep => ep.Employee)
				.ToList();

			return View(projects);
		}

		// CREATE (GET)
		public IActionResult Create()
		{
			ViewBag.Employees = _context.Employees.ToList();
			return View();
		}

		// CREATE (POST)
		[HttpPost]
		public IActionResult Create(Project project, int[] employeeIds)
		{
			_context.Projects.Add(project);
			_context.SaveChanges();

			foreach (var eid in employeeIds)
			{
				_context.EmployeeProjects.Add(new EmployeeProject
				{
					EmployeeId = eid,
					ProjectId = project.ProjectId,
					AssignedDate = DateTime.Now
				});
			}

			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		// DETAILS
		public IActionResult Details(int id)
		{
			var project = _context.Projects
				.Include(p => p.EmployeeProjects)
				.ThenInclude(ep => ep.Employee)
				.FirstOrDefault(p => p.ProjectId == id);

			return View(project);
		}

		// EDIT (GET)
		public IActionResult Edit(int id)
		{
			var project = _context.Projects.Find(id);

			ViewBag.Employees = _context.Employees.ToList();

			return View(project);
		}

		// EDIT (POST)
		[HttpPost]
		public IActionResult Edit(Project project, int[] employeeIds)
		{
			_context.Projects.Update(project);

			// remove old assignments
			var existing = _context.EmployeeProjects
				.Where(ep => ep.ProjectId == project.ProjectId);

			_context.EmployeeProjects.RemoveRange(existing);

			// add new assignments
			foreach (var eid in employeeIds)
			{
				_context.EmployeeProjects.Add(new EmployeeProject
				{
					EmployeeId = eid,
					ProjectId = project.ProjectId,
					AssignedDate = DateTime.Now
				});
			}

			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		// DELETE
		public IActionResult Delete(int id)
		{
			var project = _context.Projects.Find(id);

			var relations = _context.EmployeeProjects
				.Where(ep => ep.ProjectId == id);

			_context.EmployeeProjects.RemoveRange(relations);
			_context.Projects.Remove(project);

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}
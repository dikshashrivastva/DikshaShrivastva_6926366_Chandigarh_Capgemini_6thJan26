using EmployeeProjectManagementSystem.Data;
using EmployeeProjectManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProjectManagementSystem.Controllers
{
	public class EmployeesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public EmployeesController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var employees = _context.Employees
				.Include(e => e.Department)
				.ToList();

			return View(employees);
		}

		public IActionResult Create()
		{
			ViewBag.Departments = _context.Departments.ToList();
			ViewBag.Projects = _context.Projects.ToList();
			return View();
		}

		public IActionResult Details(int id)
		{
			var employee = _context.Employees
				.Include(e => e.Department)
				.FirstOrDefault(e => e.EmployeeId == id);

			return View(employee);
		}

		public IActionResult Edit(int id)
		{
			var employee = _context.Employees.Find(id);

			ViewBag.Departments = _context.Departments.ToList();
			ViewBag.Projects = _context.Projects.ToList();

			return View(employee);
		}

		[HttpPost]
		public IActionResult Edit(Employee employee, int[] projectIds)
		{
			_context.Employees.Update(employee);

			var existing = _context.EmployeeProjects
				.Where(ep => ep.EmployeeId == employee.EmployeeId);

			_context.EmployeeProjects.RemoveRange(existing);

			foreach (var pid in projectIds)
			{
				_context.EmployeeProjects.Add(new EmployeeProject
				{
					EmployeeId = employee.EmployeeId,
					ProjectId = pid,
					AssignedDate = DateTime.Now
				});
			}

			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var emp = _context.Employees.Find(id);

			_context.Employees.Remove(emp);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult Create(Employee employee, int[] projectIds)
		{
			_context.Employees.Add(employee);
			_context.SaveChanges();

			foreach (var pid in projectIds)
			{
				_context.EmployeeProjects.Add(new EmployeeProject
				{
					EmployeeId = employee.EmployeeId,
					ProjectId = pid,
					AssignedDate = DateTime.Now
				});
			}

			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}

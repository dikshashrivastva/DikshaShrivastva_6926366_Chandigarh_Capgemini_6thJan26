using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Models;
using System.Linq;

namespace UniversityManagementSystem.Controllers
{
	public class CoursesController : Controller
	{
		private readonly UniversityContext _context;

		public CoursesController(UniversityContext context)
		{
			_context = context;
		}

		// LIST COURSES
		public IActionResult Index()
		{
			var courses = _context.Courses.ToList();
			return View(courses);
		}

		// CREATE PAGE
		public IActionResult Create()
		{
			return View();
		}

		// SAVE COURSE
		[HttpPost]
		public IActionResult Create(Course course)
		{
			
				_context.Courses.Add(course);
				_context.SaveChanges();
				
			

			return View(course);
		}

		// EDIT PAGE
		public IActionResult Edit(int id)
		{
			var course = _context.Courses.Find(id);
			return View(course);
		}

		// UPDATE COURSE
		[HttpPost]
		public IActionResult Edit(Course course)
		{
			_context.Courses.Update(course);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		// DELETE PAGE
		public IActionResult Delete(int id)
		{
			var course = _context.Courses.Find(id);
			return View(course);
		}

		// CONFIRM DELETE
		[HttpPost]
		public IActionResult Delete(Course course)
		{
			_context.Courses.Remove(course);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
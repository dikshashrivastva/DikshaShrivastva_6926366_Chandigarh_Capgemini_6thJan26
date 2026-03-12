using Microsoft.AspNetCore.Mvc;
using UniversityManagementSystem.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace UniversityManagementSystem.Controllers
{
	public class StudentsController : Controller
	{
		private readonly UniversityContext _context;

		public StudentsController(UniversityContext context)
		{
			_context = context;
		}

		// LIST STUDENTS
		public IActionResult Index()
		{
			var students = _context.Students.ToList();
			return View(students);
		}

		// CREATE PAGE
		
		public IActionResult Create()
		{
			return View();
		}

		// SAVE STUDENT
		[HttpPost]
		[HttpPost]
		public IActionResult Create(Student student)
		{
			_context.Students.Add(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		// EDIT PAGE
		public IActionResult Edit(int id)
		{
			var student = _context.Students.Find(id);
			return View(student);
		}

		// UPDATE STUDENT
		[HttpPost]
		public IActionResult Edit(Student student)
		{
			_context.Students.Update(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}

		// DELETE PAGE
		public IActionResult Delete(int id)
		{
			var student = _context.Students.Find(id);
			return View(student);
		}

		// CONFIRM DELETE
		[HttpPost]
		public IActionResult Delete(Student student)
		{
			_context.Students.Remove(student);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
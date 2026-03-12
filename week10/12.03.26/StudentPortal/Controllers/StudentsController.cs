using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Services;
using System.Collections.Generic;

namespace StudentPortal.Controllers
{
	public class StudentsController : Controller
	{
		private readonly IRequestLogService _logService;

		public StudentsController(IRequestLogService logService)
		{
			_logService = logService;
		}

		public IActionResult Index()
		{
			var students = new List<Student>
			{
				new Student{ Id=1, Name="Diksha", Course="CSE"},
				new Student{ Id=2, Name="Khushi", Course="IT"}
			};

			ViewBag.Logs = _logService.GetLogs();

			return View(students);
		}
	}
}
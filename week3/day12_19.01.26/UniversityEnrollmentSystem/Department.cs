using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityEnrollmentSystem
{
	class Department
	{
		public string DepartmentName { get; private set; }
		private List<Course> courses = new List<Course>();

		public Department(string name)
		{
			DepartmentName = name;
		}

		public void AddCourse(Course course)
		{
			courses.Add(course);
		}

		public void DisplayCourses()
		{
			Console.WriteLine("Courses in " + DepartmentName + ":");
			foreach (var c in courses)
			{
				Console.WriteLine("- " + c.CourseName);
			}
		}
	}
}

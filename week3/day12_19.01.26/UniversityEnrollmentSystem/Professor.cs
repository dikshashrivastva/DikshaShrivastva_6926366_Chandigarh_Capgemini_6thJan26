using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityEnrollmentSystem
{
	class Professor : Person
	{
		private List<Course> assignedCourses = new List<Course>();

		public Professor(int id, string name, string email)
			: base(id, name, email)
		{
		}

		public void AssignCourse(Course course)
		{
			assignedCourses.Add(course);
		}

		public void ViewSchedule()
		{
			Console.WriteLine("Professor Schedule:");
			foreach (var c in assignedCourses)
			{
				Console.WriteLine("- " + c.CourseName);
			}
		}
	}
}

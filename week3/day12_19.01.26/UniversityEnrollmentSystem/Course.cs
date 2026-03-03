using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityEnrollmentSystem
{
    internal class Course
    {
		public string CourseCode { get; private set; }
		public string CourseName { get; private set; }

		public Course(string code, string name)
		{
			CourseCode = code;
			CourseName = name;
		}
	}
}

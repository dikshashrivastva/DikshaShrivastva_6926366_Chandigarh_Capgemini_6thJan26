namespace ConsoleApp1
{
	internal class Program
	{
		class Student
		{
			public int StudentID { get; set; }
			public string Name { get; set; }
			public int Age { get; set; }
			public int DepartmentID { get; set; }
		}

		class Department
		{
			public int DepartmentID { get; set; }
			public string DepartmentName { get; set; }
		}

		class Course
		{
			public int CourseID { get; set; }
			public string CourseName { get; set; }
			public int DepartmentID { get; set; }
		}

		class Enrollment
		{
			public int EnrollmentID { get; set; }
			public int StudentID { get; set; }
			public int CourseID { get; set; }
			public string Grade { get; set; }
		}
		static void Main(string[] args)
		{

			List<Student> students = new List<Student>{
new Student{StudentID=1,Name="Amit",Age=20,DepartmentID=1},
new Student{StudentID=2,Name="Riya",Age=21,DepartmentID=2},
new Student{StudentID=3,Name="Karan",Age=22,DepartmentID=1},
new Student{StudentID=4,Name="Sneha",Age=20,DepartmentID=3}
};

			List<Department> departments = new List<Department>{
new Department{DepartmentID=1,DepartmentName="Computer"},
new Department{DepartmentID=2,DepartmentName="Mechanical"},
new Department{DepartmentID=3,DepartmentName="Electrical"}
};

			List<Course> courses = new List<Course>{
new Course{CourseID=1,CourseName="CSharp",DepartmentID=1},
new Course{CourseID=2,CourseName="DBMS",DepartmentID=1},
new Course{CourseID=3,CourseName="Thermodynamics",DepartmentID=2},
new Course{CourseID=4,CourseName="Circuits",DepartmentID=3}
};

			List<Enrollment> enrollments = new List<Enrollment>{
new Enrollment{EnrollmentID=1,StudentID=1,CourseID=1,Grade="A"},
new Enrollment{EnrollmentID=2,StudentID=1,CourseID=2,Grade="B"},
new Enrollment{EnrollmentID=3,StudentID=2,CourseID=3,Grade="A"},
new Enrollment{EnrollmentID=4,StudentID=3,CourseID=1,Grade="C"},
new Enrollment{EnrollmentID=5,StudentID=4,CourseID=4,Grade="B"}
};

		}
	}
}

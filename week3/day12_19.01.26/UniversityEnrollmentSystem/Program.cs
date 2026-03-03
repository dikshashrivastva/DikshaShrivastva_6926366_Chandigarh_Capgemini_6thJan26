using System.Security.Cryptography.X509Certificates;

namespace UniversityEnrollmentSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

			Course c1 = new Course("CS101", "Data Structures");
			Course c2 = new Course("CS102", "Operating Systems");

			Department cs = new Department("Computer Science");
			cs.AddCourse(c1);
			cs.AddCourse(c2);

			Student s1 = new Student(1, "Diksha", "diksha@gmail.com");
			s1.RegisterCourse(c1);
			s1.RegisterCourse(c2);

			Professor p1 = new Professor(101, "Dr. Sharma", "sharma@uni.edu");
			p1.AssignCourse(c1);

			Staff st1 = new Staff(201, "Rahul", "rahul@uni.edu", "Clerk");

			Console.WriteLine("\n--- Student Profile ---");
			s1.Display();
			s1.ViewSchedule();

			Console.WriteLine("\n--- Professor Profile ---");
			p1.Display();
			p1.ViewSchedule();

			Console.WriteLine("\n--- Staff Profile ---");
			st1.Display();
			st1.DisplayRole();

			Console.WriteLine("\n--- Department Info ---");
			cs.DisplayCourses();
		}
    }
}

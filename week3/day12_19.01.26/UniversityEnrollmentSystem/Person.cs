using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityEnrollmentSystem
{
	internal class Person
	{
		private int id;
		private string name;
		private string email;

		public Person(int id, string name, string email)
		{
			this.id = id;
			this.name = name;
			this.email = email;
		}

		public void Display()
		{
			Console.WriteLine("ID    : " + id);
			Console.WriteLine("Name  : " + name);
			Console.WriteLine("Email : " + email);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityEnrollmentSystem
{
	class Staff : Person
	{
		private string role;

		public Staff(int id, string name, string email, string role)
			: base(id, name, email)
		{
			this.role = role;
		}

		public void DisplayRole()
		{
			Console.WriteLine("Staff Role: " + role);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
	class Doctor : Person
	{
		public string Specialization;

		public Doctor(int id, string name, string specialization)
			: base(id, name)
		{
			Specialization = specialization;
		}
	}
}

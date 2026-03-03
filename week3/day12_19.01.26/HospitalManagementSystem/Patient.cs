using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
	class Patient : Person
	{
		private MedicalRecord record;

		public Patient(int id, string name)
			: base(id, name)
		{
			record = new MedicalRecord();
		}

		public MedicalRecord GetRecord()
		{
			return record;
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
	class MedicalRecord
	{
		private List<string> history = new List<string>();

		public void AddRecord(string details)
		{
			history.Add(details);
		}

		public void ViewHistory()
		{
			Console.WriteLine("Medical History:");
			foreach (var h in history)
			{
				Console.WriteLine("- " + h);
			}
		}
	}
}

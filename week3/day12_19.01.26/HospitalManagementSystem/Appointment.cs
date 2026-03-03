using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
	class Appointment
	{
		public Patient Patient;
		public Doctor Doctor;
		public DateTime Date;

		public Appointment(Patient p, Doctor d, DateTime date)
		{
			Patient = p;
			Doctor = d;
			Date = date;
		}

		public void ShowAppointment()
		{
			Console.WriteLine("Patient : " + Patient.Name);
			Console.WriteLine("Doctor  : " + Doctor.Name);
			Console.WriteLine("Date    : " + Date.ToShortDateString());
		}
	}
}

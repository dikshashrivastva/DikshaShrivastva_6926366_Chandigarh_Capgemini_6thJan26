using HospitalManagementSystem;

namespace HospitalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
		Patient p1 = new Patient(1, "Diksha");
		Doctor d1 = new Doctor(101, "Dr. Sharma", "Cardiology");

		Appointment ap = new Appointment(p1, d1, DateTime.Now);

		p1.GetRecord().AddRecord("Fever");
		p1.GetRecord().AddRecord("Blood Test Done");

		Console.WriteLine("--- Appointment ---");
		ap.ShowAppointment();

		Console.WriteLine("\n--- Medical Record ---");
		p1.GetRecord().ViewHistory();
	}
    }
}

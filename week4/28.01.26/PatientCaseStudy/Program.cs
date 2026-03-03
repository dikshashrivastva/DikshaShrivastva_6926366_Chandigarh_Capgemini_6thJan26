using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PatientCaseStudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patientList = new List<Patient>();
            int noOfPatient, i;
            string name, city, illness;
            int age;

            Console.WriteLine("Enter the number of patients");
            noOfPatient = int.Parse(Console.ReadLine());
            //Patient patient = new Patient();
            for( i = 0; i < noOfPatient; i++)
            {
                Console.WriteLine("Enter patient"+(i+1)+"details");
                Console.WriteLine("Enter the name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter the age:");
                age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the illness:");
                illness = Console.ReadLine();
                Console.WriteLine("Enter the city:");
                city = Console.ReadLine();

                Patient patient = new Patient(name, age, illness, city);
                patientList.Add(patient); 
            }
            int choice;
            PatientBO patientBO=new PatientBO();
            string opt;
            do
            {
				Console.WriteLine("Enter your choice:\n1)Display Patient Details\n" +
                    "2)Display Youngest Patient Details");
				Console.WriteLine("3)Display Employees from City");
				choice = int.Parse(Console.ReadLine());
				switch (choice)
				{
					case 1:
						Console.WriteLine("Enter patient name:");
						name = Console.ReadLine();
						patientBO.DisplayPatientDetails(patientList, name);
						break;

					case 2:
						patientBO.DisplayYoungestPatientDetails(patientList);
						break;

					case 3:
						Console.WriteLine("Enter city");
						city = Console.ReadLine();
						patientBO.displayPatientsFromCity(patientList, city);
						break;

					default:
						break;

				}
				Console.WriteLine("Do you want to continue(Yes/No)?");
				opt = Console.ReadLine();
			} while (opt.Equals("Yes"));

		}
	}
    
}

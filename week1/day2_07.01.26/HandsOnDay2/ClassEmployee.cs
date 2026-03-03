using System;
using System.Collections.Generic;
using System.Text;

namespace HandsOnDay2
{
    internal class ClassEmployee
    {
		public int EmpId, Eage;
		public string EName, Eaddress;
		public void GetEmpData()
		{
			Console.Write("Enter the emp Details: ");
			this.EmpId = Convert.ToInt32(Console.ReadLine());
			this.EName = Console.ReadLine();
			this.Eaddress = Console.ReadLine();
			this.Eage = Convert.ToInt32(Console.ReadLine());
		}
		public void displayData()
		{
			Console.WriteLine("Emp Id=" + this.EmpId);
			Console.WriteLine("Emp Name=" + this.EName);
			Console.WriteLine("Emp Address=" + this.Eaddress);
			Console.WriteLine("Emp Age=" + this.Eage);
		}
		static void Main(string[] args)
		{
			ClassEmployee emp = new ClassEmployee();
			emp.GetEmpData();
			emp.displayData();

		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalManagementSystem
{
    internal class Person
    {
		public int Id;
		public string Name;

		public Person(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public void Display()
		{
			Console.WriteLine("ID   : " + Id);
			Console.WriteLine("Name : " + Name);
		}
	}
}

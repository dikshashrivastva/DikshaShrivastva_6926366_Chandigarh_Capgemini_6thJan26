using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineBankProject
{
		struct Customer
		{
			public int CustomerId;
			public string Name;
			public string Email;

			public void DisplayCustomer()
			{
			    Console.WriteLine("This display is through Struct");
				Console.WriteLine("Customer ID: " + CustomerId);
				Console.WriteLine("Name: " + Name);
				Console.WriteLine("Email: " + Email);
			}
		}
	}


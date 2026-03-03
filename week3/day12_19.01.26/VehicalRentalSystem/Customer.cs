using System;
using System.Collections.Generic;
using System.Text;

namespace VehicalRentalSystem
{
	class Customer
	{
		public int CustomerId { get; private set; }
		public string Name { get; private set; }

		public Customer(int id, string name)
		{
			CustomerId = id;
			Name = name;
		}
	}

}

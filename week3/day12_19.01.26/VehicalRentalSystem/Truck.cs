using System;
using System.Collections.Generic;
using System.Text;

namespace VehicalRentalSystem
{
	class Truck : Vehicle
	{
		public Truck(int id, string model)
			: base(id, model, 3000)
		{
		}

		public override double CalculateRent(int days)
		{
			return base.CalculateRent(days) + 2000; // heavy vehicle charge
		}
	}

}

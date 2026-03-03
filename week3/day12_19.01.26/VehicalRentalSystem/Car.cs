using System;
using System.Collections.Generic;
using System.Text;

namespace VehicalRentalSystem
{
	class Car : Vehicle
	{
		public Car(int id, string model)
			: base(id, model, 1500)
		{
		}

		public override double CalculateRent(int days)
		{
			return base.CalculateRent(days) + 500; // service charge
		}
	}

}

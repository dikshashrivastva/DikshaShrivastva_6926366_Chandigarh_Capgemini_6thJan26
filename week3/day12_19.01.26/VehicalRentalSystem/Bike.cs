using System;
using System.Collections.Generic;
using System.Text;

namespace VehicalRentalSystem
{
	class Bike : Vehicle
	{
		public Bike(int id, string model)
			: base(id, model, 500)
		{
		}
	}

}

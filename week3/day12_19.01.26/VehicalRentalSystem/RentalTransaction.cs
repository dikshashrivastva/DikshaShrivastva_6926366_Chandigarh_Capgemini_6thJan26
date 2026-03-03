using System;
using System.Collections.Generic;
using System.Text;

namespace VehicalRentalSystem
{
	class RentalTransaction
	{
		private Vehicle vehicle;
		private Customer customer;
		private int days;
		private double totalAmount;

		public RentalTransaction(Customer customer, Vehicle vehicle, int days)
		{
			this.customer = customer;
			this.vehicle = vehicle;
			this.days = days;
		}

		public void RentVehicle()
		{
			if (vehicle.IsAvailable())
			{
				vehicle.Rent();
				totalAmount = vehicle.CalculateRent(days);
				Console.WriteLine("Vehicle rented successfully.");
			}
			else
			{
				Console.WriteLine("Vehicle not available.");
			}
		}

		public void ReturnVehicle()
		{
			vehicle.Return();
			Console.WriteLine("Vehicle returned.");
		}

		public void ShowBill()
		{
			Console.WriteLine("Customer : " + customer.Name);
			Console.WriteLine("Days     : " + days);
			Console.WriteLine("Total ₹  : " + totalAmount);
		}
	}
}

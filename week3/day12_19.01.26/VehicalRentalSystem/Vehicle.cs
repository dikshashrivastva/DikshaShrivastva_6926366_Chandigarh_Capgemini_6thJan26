using System;

class Vehicle
{
	private int vehicleId;
	private string model;
	protected double ratePerDay;
	private bool isAvailable = true;

	public Vehicle(int id, string model, double rate)
	{
		vehicleId = id;
		this.model = model;
		ratePerDay = rate;
	}

	public bool IsAvailable()
	{
		return isAvailable;
	}

	public void Rent()
	{
		isAvailable = false;
	}

	public void Return()
	{
		isAvailable = true;
	}

	public virtual double CalculateRent(int days)
	{
		return ratePerDay * days;
	}

	public void DisplayVehicle()
	{
		Console.WriteLine($"ID: {vehicleId}, Model: {model}, Rate/Day: {ratePerDay}, Available: {isAvailable}");
	}
}

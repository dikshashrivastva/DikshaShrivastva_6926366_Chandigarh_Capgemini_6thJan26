namespace VehicalRentalSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Vehicle car = new Car(1, "Honda City");
			Vehicle bike = new Bike(2, "Royal Enfield");

			Customer c1 = new Customer(101, "Diksha");

			RentalTransaction t1 = new RentalTransaction(c1, car, 3);
			t1.RentVehicle();
			t1.ShowBill();
			t1.ReturnVehicle();

			Console.WriteLine("--------------------");

			RentalTransaction t2 = new RentalTransaction(c1, bike, 2);
			t2.RentVehicle();
			t2.ShowBill();
		}
    }
}

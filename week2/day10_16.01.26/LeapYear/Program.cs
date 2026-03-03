namespace LeapYear
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int year;
            Console.WriteLine("Enter a year:");
            year = int.Parse(Console.ReadLine());
            if ((year % 400 == 0) || (year%4==0 && year % 100 != 0)){
                Console.WriteLine(year + " is a Leap year");
            }
            else
            {
				Console.WriteLine(year + " is not a Leap year");
			}

			
        }
    }
}

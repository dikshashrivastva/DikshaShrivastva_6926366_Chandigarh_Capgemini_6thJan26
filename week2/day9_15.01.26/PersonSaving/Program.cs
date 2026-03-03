namespace PersonSaving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal salary;
            Console.WriteLine("Enter your Salary");
            salary = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the no. of days You Worked:");
            int days=int.Parse(Console.ReadLine());

            if (days == 31)
            {
                salary = salary + 500;
            }
            
            decimal saving = salary - ((0.5m * salary) + (0.2m * salary));

            
            Console.WriteLine("You Saved: "+saving);
        }
    }
}

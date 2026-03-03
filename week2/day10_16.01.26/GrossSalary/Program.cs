using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GrossSalary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //			7.Calculate the gross salary of the employee given da and hra is 75 % and 50 % of basic salary

            //(Business rule: Store - 1 in the output variable if basic pay < 0 and - 2 in the output variable if basic
            //pay > 10000 and - 3 in the output variable if number of working days > 31)

            decimal salary;
            Console.WriteLine("Enter your base Salary:");
            salary = decimal.Parse(Console.ReadLine());

            decimal da = 0.75m * salary;
            decimal hra = 0.5m * salary;
            
            Console.WriteLine("Gross salary=" + (da+hra+salary));
        }
    }
}

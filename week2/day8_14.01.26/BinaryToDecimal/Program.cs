namespace BinaryToDecimal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //			Convert the given binary number into the decimal number. Consider input1 is the binary number.
            //Eg:
            //Input1 = 1001
            //Output1 = 9
            //Business Rules:
            //i)	If the given input is not a binary value store -1 to the output variable.
            //ii)	If the given input is greater than 11111 store - 2 to the output variable.
            int binForm = 1001;
            int decForm=0,exp=0;
            while (binForm > 0)
            {
                int rem = binForm % 10;
                decForm += rem * (int)Math.Pow(2, exp);
                exp++;
                binForm /= 10;
            }

			Console.WriteLine("Decimal Form=" + decForm);
        }
    }
}

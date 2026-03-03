namespace PerformOperation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input1, input2;
            Console.WriteLine("enter a number:");
            input1 = int.Parse(Console.ReadLine());
            Console.WriteLine("enter another number:");
            input2 = int.Parse(Console.ReadLine());

            int ch;
            Console.WriteLine("Enter your your operation:");
            ch = int.Parse(Console.ReadLine());

            switch (ch)
            {
                case 1:
                    Console.WriteLine("Addition=" + (input1 + input2));
                    break;
                case 2:
                    Console.WriteLine("Substraction=" + (input1 - input2));
                    break;
                case 3:
                    Console.WriteLine("Multiplication= " + (input1 * input2));
                    break;
                case 4:
                    Console.WriteLine("Divide= " + (input1 / input2));
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }

            //Console.WriteLine("Hello, World!");
        }
    }
}

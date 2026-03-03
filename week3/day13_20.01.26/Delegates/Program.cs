namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MultiClass obj = new MultiClass();
            Math m = new Math(obj.add);
            m += obj.sub;m += obj.mul;
            m += obj.div;
            m(100, 50);
            Console.WriteLine();
            m(450, 70);
            Console.WriteLine();
            m -= obj.div;
            m(625, 25);
            Console.ReadLine();
        }
    }
}

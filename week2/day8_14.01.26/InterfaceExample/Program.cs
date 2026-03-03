namespace InterfaceExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            C3 obj1 = new C3();
            Inter1 obj2 = (Inter1)obj1;
            Inter2 obj3 = (Inter2)obj1;
            obj2.f1();
            obj3.f1();
            Console.Read();
        }
    }
}

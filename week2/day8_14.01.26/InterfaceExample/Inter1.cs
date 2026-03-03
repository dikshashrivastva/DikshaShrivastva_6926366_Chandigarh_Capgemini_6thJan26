using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceExample
{
    internal interface Inter1
    {
        void f1();

    }
    interface Inter2
    {
        void f1();
    }
    class C3: Inter1, Inter2
    {
        void Inter1.f1()
        {
            Console.WriteLine("this is overriding function of inter1 and inter 2 interfaces");
        }
        void Inter2.f1()
        {
            Console.WriteLine("This is overriding function too");
        }
    }
}

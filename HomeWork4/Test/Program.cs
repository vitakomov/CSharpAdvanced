using System;

namespace Test
{
    class Program
    {
        static void Main()
        {
            object a = 'a';
            object b = 'a';
            string c;
            c = (a.Equals(b)) ? "Equal":"Not equal";
            Console.WriteLine(c);
            Console.ReadLine();
        }
    }
}

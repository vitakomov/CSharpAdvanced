using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = new int[10];
            
            //for (int i = 0; i < arr.Length; i++)
            //    arr[i] = rnd.Next(0, 100);
            //Array.Sort(arr);
            //for (int i = 0; i < arr.Length; i++)
            //    Console.WriteLine(arr[i]);
            //Console.ReadLine();
            Random rnd = new Random();
            int c=0;
            List<int> list = new List<int>();
            for (int i = 0; i < 15; i++)
                {
                c = rnd.Next(0, 100);
                list.Add(c);
                }
            foreach (var i in list)
                Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> lst = new List<int>()
            //{0,0,60,4,7,3,5,7 };
            //foreach (int val in lst.Distinct())
            //{
            //    Console.WriteLine(val + " - " + lst.Count(x => x == val) + " раз");
            //}
            //Console.WriteLine();

            List<object> lst1 = new List<object>()
            {0,0,60,4,7,3,5,7 };
            var newList = GetEquals<object>(lst1);
            foreach (object val1 in newList)
            {
                Console.WriteLine(val1);
            }
            Console.ReadLine();
        }
        private static IDictionary<T, int> GetEquals<T>(ICollection<T> list)
        {
            Dictionary<T, int> found = new Dictionary<T, int>();
            foreach (T val in list.Distinct())
            {
                found.Add(val, list.Count(x => x.Equals(val)));
            }
            return found;
        }
    }
}

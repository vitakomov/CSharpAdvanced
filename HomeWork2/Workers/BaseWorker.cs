using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    abstract class BaseWorker
    {
        public string Name { get; set; }
        public string SecondName { get; set; }
        public double Salary { get; set; }
        public abstract double MediumSallary();
        public BaseWorker(string Name, string SecondName, double Salary)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class FixedWorker : BaseWorker
    {
        public FixedWorker(string Name, string SecondName, double Salary) :base(Name, SecondName, Salary)   
        {

        }
        public override double MediumSallary()
        {
            return Salary;
        }
    }
}

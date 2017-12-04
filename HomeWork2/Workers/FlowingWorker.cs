using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class FlowingWorker : BaseWorker
    {
        public FlowingWorker(string Name, string SecondName, double Salary) : base(Name, SecondName, Salary)
        {

        }
        public override double MediumSallary()
        {
            return Salary = 20.8 * 8 * Salary;
        }
    }
}

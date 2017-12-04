using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class ArrayWorkers: IEnumerable<ArrayWorkers>
    {

        public ArrayWorkers()
        {
        BaseWorker[] depar = new BaseWorker[5];
        depar[0] = new FixedWorker("Иван", "Петров", 8000);
        depar[1] = new FlowingWorker("Сергей", "Иванов", 300);
        depar[2] = new FixedWorker("Кузьмин", "Григорий", 6000);
        depar[3] = new FlowingWorker("Коперник", "Михаил", 600);
        depar[4] = new FixedWorker("Васюткин", "Дмитрий", 9600);
        }

        public IEnumerator<ArrayWorkers> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class ListWorkers:IEnumerable<BaseWorker>
    {
        List<BaseWorker> list;
        public ListWorkers(params BaseWorker[] Users)
        {
            list = new List<BaseWorker>();
            list.AddRange(Users);
        }

        public IEnumerator<BaseWorker> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

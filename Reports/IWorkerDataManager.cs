using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    interface IWorkerDataManager
    {
        T NewWorker<T>(string Name) where T : Worker;
        void SetVassals(Worker worker, List<Worker> vassals);
    }
}

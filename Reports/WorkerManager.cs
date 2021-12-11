using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    class WorkerManager
    {
        private IWorkerDataManager Data;

        public WorkerManager(IWorkerDataManager data)
        {
            Data = data;
        }
        public T NewWorker<T>(string Name) where T : Worker
        {
            return Data.NewWorker<T>(Name);
        }
        public void SetVassals(Worker worker, List<Worker> vassals)
        {
            Data.SetVassals(worker, vassals);
        }
    }
}

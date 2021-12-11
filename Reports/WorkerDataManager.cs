using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    public class WorkerDataManager : IWorkerDataManager
    {

        List<Worker> Workers = new List<Worker>();
        public T NewWorker<T>(string Name) where T : Worker
        {
            T GetObject<T>(params object[] args)
            {
                return (T)Activator.CreateInstance(typeof(T), args);
            }

            T Out = GetObject<T>(Workers.Count, Name);
            Workers.Add(Out);
            return Out;
        }


        public void SetVassals(Worker worker, List<Worker> vassals)
        {
            Workers.Find(item => item.ID == worker.ID).SetVassals(vassals);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    public class TaskDataManager : ITaskDataManager
    {
        private List<Task> Tasks = new List<Task>();


        public T NewTask<T>(string name) where T : Task
        {
            T GetObject<T>(params object[] args)
            {
                return (T)Activator.CreateInstance(typeof(T), args);
            }

            T Out = GetObject<T>(Tasks.Count, name);
            Tasks.Add(Out);
            return Out;
        }


        public List<Task> FindWorkersTasks(Worker worker)
        {
            return Tasks.FindAll(item => item.Owner.ID == worker.ID);
        }

        public bool DoesTaskExists(Task task)
        {
            return (Tasks.Find(item => item.ID == task.ID) != null);
        }


        public void SetOwner(Task task, Worker worker)
        {
            Tasks.Find(item => item.ID == task.ID).Owner = worker;
        }

        public Task FindByID(int id)
        {
            return Tasks.Find(item => item.ID == id);
        }

        public List<Task> FindVassalsTasks(Worker worker)
        {
            List<Task> Out = new List<Task>();
            foreach (Worker vassal in worker.Vassals)
            {
                List<Task> tasks = FindWorkersTasks(vassal);
                if (tasks == null)
                    Out.AddRange(tasks);
            }
            return Out;
        }

        public List<Task> WhoWorked(Worker worker)
        {
            return Tasks.FindAll(item => item.DoesHeWorked(worker));
        }

        public List<Task> GetTasksForPeriod(Worker worker, KeyValuePair<DateTime, DateTime> Period)
        {
            return Tasks.FindAll(item => (item.State == "Resolved"
            && item.ChangeDate >= Period.Key
            && item.ChangeDate < Period.Value));
        }
    }
}

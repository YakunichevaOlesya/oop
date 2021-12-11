using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    public class TaskManager
    {
        private ITaskDataManager Data;

        public TaskManager(ITaskDataManager data)
        {
            Data = data;
        }

        public T NewTask<T>(string name) where T : Task
        {
            return Data.NewTask<T>(name);
        }

        public void SetOwner(Task task, Worker worker)
        {

            if (!Data.DoesTaskExists(task))
                throw new Exception("Task doesn't exist");

            task.Owner = worker;
        }

        public Task FindByID(int id)
        {
            return Data.FindByID(id);
        }

        public List<Task> FindWorkersTasks(Worker worker)
        {
            return Data.FindWorkersTasks(worker);
        }

        public List<Task> FindVassalsTasks(Worker worker)
        {
            return Data.FindVassalsTasks(worker);
        }

        public List<Task> WhoWorked(Worker worker)
        {
            return Data.WhoWorked(worker);
        }

        public bool DoWork(Worker worker, Task task)
        {
            return task.DoWork(worker);
        }
        public void NewComment(Worker worker, Task task, string comment)
        {
            task.NewComment(worker, comment);
        }

        public List<Task> GetTasksForPeriod(Worker worker, KeyValuePair<DateTime, DateTime> Period)
        {
            return Data.GetTasksForPeriod(worker, Period);
        }

    }
}

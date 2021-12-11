using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    public interface ITaskDataManager
    {
        T NewTask<T>(string name) where T : Task;
        List<Task> FindWorkersTasks(Worker worker);
        bool DoesTaskExists(Task task);
        void SetOwner(Task task, Worker worker);
        Task FindByID(int id);
        List<Task> FindVassalsTasks(Worker worker);
        List<Task> WhoWorked(Worker worker);
        List<Task> GetTasksForPeriod(Worker worker, KeyValuePair<DateTime, DateTime> Period);
    }
    
}

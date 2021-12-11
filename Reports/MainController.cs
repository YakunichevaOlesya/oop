using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    class MainController
    {
        public WorkerManager WorkerController;
        public ReportManager ReportController;
        public TaskManager TaskController;

        public MainController(WorkerDataManager wdata, ReportDataManager rdata, TaskDataManager tdata)
        {
            WorkerController = new WorkerManager(wdata);
            ReportController = new ReportManager(rdata);
            TaskController = new TaskManager(tdata);
        }

    }
}

using System;
using System.Collections.Generic;

namespace Task6_Report.Tests
{
    public class ReportTest
    {
        private readonly MainController _mc;
        private readonly Worker _ivan;
        private readonly Worker _peter;
        private readonly TeamLead _boss;
        private readonly Task _task;
        private SprintReport _report;
        public ReportTest()
        {
            _mc = new MainController(new WorkerDataManager(), new ReportDataManager(), new TaskDataManager());

            _ivan = _mc.WorkerController.NewWorker<Worker>("Ivan");
            _peter = _mc.WorkerController.NewWorker<Worker>("Petr");
            _boss = _mc.WorkerController.NewWorker<TeamLead>("Boss");


            _task = _mc.TaskController.NewTask<ConcreteTask>("task1");
            _mc.TaskController.SetOwner(_task, _ivan);
            //_mc.WorkerController.SetVassals(_boss, new List<Worker>{_ivan, _peter});
        }
        public bool CheckWorkHaveDone()
        {
            if (!_mc.TaskController.DoWork(_ivan, _task))
            {
                throw new ReportException("Error check work have done");
            }
            return true;
        }

        public bool CheckSprint()
        {
            try
            {
                _report = _mc.ReportController.NewSprintReport(_boss,
                    new KeyValuePair<DateTime, DateTime>(DateTime.Now, DateTime.Now.AddDays(3)));
                return false;
            }
            catch (Exception e)
            {
                return true;
            }
        }

        public bool CheckOwnerIsSet()
        {
            if (_task.Owner != _ivan)
            {
                throw new ReportException("Error check owner is set");
            }
            return true;
        }

        public bool CheckVassalsAreOk()
        {
            if (!_boss.Vassals.Contains(_ivan) || !_boss.Vassals.Contains(_peter))
            {
                throw new ReportException("Error check vassals are set");
            }
            return true;
        }
    }
}

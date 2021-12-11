using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{


    public class ReportManager
    {
        private IReportDataManager Data;

        public ReportManager(IReportDataManager data)
        {
            Data = data;
        }


        public DayReport NewDayReport(Worker worker, DateTime start)
        {
            return Data.NewDayReport(worker, start);
        }

        public SprintReport NewSprintReport(Worker worker, KeyValuePair<DateTime, DateTime> period)
        {
            if (!typeof(TeamLead).Equals(worker))
            {
                throw new Exception("You don't have rights");
            }

            return Data.NewSprintReport(worker, period);
        }

        public List<DayReport> FindVassalsReport(Worker worker)
        {
            return Data.FindVassalsReport(worker);
        }

        public List<DayReport> FindWorkersReport(Worker worker)
        {
            return Data.FindWorkersReport(worker);
        }


        public void SaveSprintReport(Worker worker, SprintReport report)
        {
            if (!typeof(TeamLead).Equals(worker))
            {
                throw new Exception("You don't have rights");
            }

            Data.SaveSprintReport(report);
        }

        public void WriteReport(Worker worker, Report report, string text)
        {
            if(report.Owner.ID != worker.ID)
            {
                throw new Exception("That's not your report");
            }
            report.Text = text;
        }
    }
}

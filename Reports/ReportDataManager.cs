using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    public class ReportDataManager : IReportDataManager
    {
        private List<DayReport> DayReports = new List<DayReport>();
        private List<SprintReport> SprintReports = new List<SprintReport>();
        List<SprintReport> SavedSprintReports = new List<SprintReport>();
        public DayReport NewDayReport(Worker worker, DateTime start) 
        {
            DayReport Out = new DayReport(DayReports.Count, worker, start);
            DayReports.Add(Out);
            return Out;
        }

        public SprintReport NewSprintReport(Worker worker, KeyValuePair<DateTime, DateTime> period)
        {
            SprintReport Out = new SprintReport(DayReports.Count, worker, period);
            SprintReports.Add(Out);
            return Out;
        }


        public List<DayReport> FindVassalsReport(Worker worker)
        {
            List<DayReport> Out = new List<DayReport>();
            foreach (Worker vassal in worker.Vassals)
            {
                List<DayReport> report = FindWorkersReport(vassal);
                if (report == null)
                    Out.AddRange(report);
            }
            return Out;
        }


        public List<DayReport> FindWorkersReport(Worker worker)
        {
            return DayReports.FindAll(item => item.Owner.ID == worker.ID);
        }


        public void SaveSprintReport(SprintReport report)
        {
            SavedSprintReports.Add(report);
        }
    }
}

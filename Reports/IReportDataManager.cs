using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    public interface IReportDataManager
    {
        DayReport NewDayReport(Worker worker, DateTime start);
        SprintReport NewSprintReport(Worker worker, KeyValuePair<DateTime, DateTime> period);
        List<DayReport> FindVassalsReport(Worker worker);
        List<DayReport> FindWorkersReport(Worker worker);
        void SaveSprintReport(SprintReport report);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    public abstract class Report
    {
        public int ID;
        public KeyValuePair<DateTime, DateTime> Period;
        public Worker Owner;
        private string text;
        public string Text { get => text; set
            {
                if ((DateTime.Now >= Period.Key) && (DateTime.Now < Period.Value))
                    text = value;
                else
                    throw new Exception("Deadline is over");
            }
        }

        public Report(int id, Worker owner, KeyValuePair<DateTime, DateTime> period)
        {
            (ID, Period, Owner) = (id, period, owner);
        }
    }


    public class DayReport : Report
    {
        public DayReport(int id, Worker owner, DateTime Start)
            : base(id, owner, new KeyValuePair<DateTime, DateTime>(Start, Start.AddDays(1))) { }
    }

    public class SprintReport : Report
    {
        public SprintReport(int id, Worker owner, KeyValuePair<DateTime, DateTime> period)
            : base(id, owner, period)
        {
            CreateDraft();
        }

        private void CreateDraft()
        {
            if (Text != "")
            {
                Text = $"Отчёт №{ID} за период: {Period.Key} - {Period.Value}";
            }
        }
    }

}

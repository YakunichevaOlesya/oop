using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6_Report
{
    public class Worker
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Worker> Vassals { get; set; }

        public Worker(int id, string name)
        {
            (ID, Name) = (id, name);
        }

        public void SetVassals(List<Worker> vassals)
        {
            Vassals.AddRange(vassals);
        }
    }

    public class TeamLead : Worker
    {
        public TeamLead(int id, string name):
            base(id, name)
        { }
    }

}

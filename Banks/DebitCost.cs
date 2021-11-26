using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task5_Bank.LocalTime;
namespace Task5_Bank
{
    public class DebitCost : Cost
    {
        public DebitCost(int id_, CostSettings settings) : base(id_)
        {
            ID = id_;
            IncreasingPercent = settings.IncreasingPercent;
        }
    }
}

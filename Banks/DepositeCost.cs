using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task5_Bank.LocalTime;

namespace Task5_Bank
{
    class DepositeCost : Cost
    {
        public DepositeCost(int id_, float money_, CostSettings settings) // нижний предел-процент
            : base(id_)
        {
            ID = id_;
            Money = money_;
            Term.AddMonths(settings.TermMonth);
            IncreasingPercent = settings.PercentageDiapazon.FindLast(item => item.Key <= money_).Value;
        }
    }
}

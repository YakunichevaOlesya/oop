using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Bank
{
    class CreditCost : Cost
    {
        public CreditCost(int id_, CostSettings settings):
            base(id_)
        {
            ID = id_;
            ComissionPercent = settings.Comission;
            BottomLimit = settings.BottomLimit;
        }
    }
}

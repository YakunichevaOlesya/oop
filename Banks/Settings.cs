using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_Bank
{

    public class CostSettings
    {
        public float Comission;
        public float BottomLimit;
        public int TermMonth;
        public List<KeyValuePair<float, float>> PercentageDiapazon = new List<KeyValuePair<float, float>>(); //нижний предел-значение
        public float IncreasingPercent;
    }
}

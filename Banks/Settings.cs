using System.Collections.Generic;

namespace Lab4
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

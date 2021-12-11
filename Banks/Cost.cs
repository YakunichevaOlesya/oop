using System;
using static Lab4.LocalTime;

namespace Lab4
{
    abstract public class Cost
    {
        public int ID = 0;
        public float IncreasingPercent = 0;
        public float ComissionPercent = 0;
        public DateTime Term = CurrentDate;
        public float BottomLimit = 0;

        public float MoneyToAdd = 0;
        public float Money { get; set; }

        public Cost(int id_)
        {
            ID = id_;
        }


        public void AddMoney(float add)
        {
                Money += add;
        }

        public bool TakeMoney(float take)
        {
            if(Money - take <= BottomLimit || Term <= CurrentDate)
            {
                Money -= take;
                return true;
            }
            else
            {
                throw new Exception("Invalid Transaction");
            }
        }
        public bool CanYouTakeMoney(float take)
        {
            return (Money - take < BottomLimit && Term <= CurrentDate);
        }

        public void DayPassed()
        {
            MoneyToAdd += Money*IncreasingPercent;
            if (Money < 0)
                MoneyToAdd += Money * ComissionPercent;
        }
        public void MonthPassed()
        {
            Money += MoneyToAdd;
            MoneyToAdd = 0;
        }



    }
}

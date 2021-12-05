using System;
using System.Collections.Generic;

namespace Lab4
{
    public class Client
    {
        public string Name;
        public string Address = "";
        public int Passport = -1;
        public bool IsVerified() => (Address != "" && Passport != -1);

        public List<Cost> Costs = new List<Cost>();
        public Client(string name_, string address_, int passport_)
        {
            Name = name_;
            Address = address_;
            Passport = passport_;
        }
        public Client(string name_)
        {
            Name = name_;
        }

        public void AddPassport(int passport)
        {
            Passport = passport;
        }

        public void AddAddress(string address)
        {
            Address = address;
        }

        public bool SendMoney(int id1, int id2, float money)
        {
            
            Cost c1 = Costs.Find(item => item.ID == id1);
            Cost c2 = Costs.Find(item => item.ID == id2);
            if (c1 != null && c2 != null)
            {
                if (c1.CanYouTakeMoney(money))
                {
                    c1.TakeMoney(money);
                    c2.AddMoney(money);
                    return true;
                }
                else
                    throw new Exception("You can not take money from this cost");
            }
            else
                throw new Exception("Cost not found");
        }


        public void DayPassed()
        {
            foreach(Cost cost in Costs)
            {
                cost.DayPassed();
            }
        }
        public void MonthPassed()
        {
            foreach (Cost cost in Costs)
            {
                cost.MonthPassed();
            }
        }
    }
}

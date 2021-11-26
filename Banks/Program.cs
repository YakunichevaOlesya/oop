using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task5_Bank.LocalTime;


namespace Task5_Bank
{

    public static class LocalTime
    {
        public static DateTime CurrentDate = DateTime.Now;
    }

    class Program
    {
        static void Main(string[] args)
        {
            CostSettings debitSettings_ = new CostSettings();
            CostSettings creditSettings_ = new CostSettings();
            CostSettings depositeSettings_ = new CostSettings();

            debitSettings_.IncreasingPercent = (float)0.03;

            depositeSettings_.PercentageDiapazon = new List<KeyValuePair<float, float>>
            {
                new KeyValuePair<float, float>(0, (float)0.03),
                new KeyValuePair<float, float>(15000, (float)0.05),
                new KeyValuePair<float, float>(50000, (float)0.07)
            };
            depositeSettings_.TermMonth = 6;

            creditSettings_.BottomLimit = -15000;
            creditSettings_.Comission = (float)0.05;

            Bank MyBank = new Bank("Sber", creditSettings_,depositeSettings_,debitSettings_);

            Client Ivan = MyBank.NewClient("Ivanov Ivan");
            Console.WriteLine($"Ivanov Ivan is Verifed: {MyBank.Clients[0].IsVerified()}"); // false
            DebitCost debit = MyBank.NewDebitCost(Ivan);

            MyBank.AddMoney(Ivan, debit, 50000);

            Ivan.AddAddress("Lenina street");
            Ivan.AddPassport(123456);

            MyBank.TakeMoney(Ivan, debit, 10000);

            CreditCost credit = MyBank.NewCreditCost(Ivan);
            MyBank.TakeMoney(Ivan, credit, 100000);

            Console.WriteLine("Money Before Month: ");
            Console.WriteLine("Debit Cost" + debit.Money);
            Console.WriteLine("Credit Cost" + credit.Money);
            MyBank.DayPassed();
            MyBank.MonthPassed();
            Console.WriteLine("Money After Month: ");
            Console.WriteLine("Debit Cost" + debit.Money);
            Console.WriteLine("Credit Cost" + credit.Money);

            int id = MyBank.SendMoney(Ivan, debit, credit, 150000);

            MyBank.BackUp(id);

            Console.ReadKey();
        }
    }
}

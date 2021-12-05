using System;
using System.Collections.Generic;
using Lab4.Tests;

namespace Lab4
{

    public static class LocalTime
    {
        public static DateTime CurrentDate = DateTime.Now;
    }

    public class Program
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

            BankTest bankTest = new BankTest(MyBank);

            try
            {
                // Check client is verified
                string result = ResultString(bankTest.CheckIsClientVerified(Ivan), "CheckIsClientVerified");
                Console.WriteLine(result);
                // Check debit cost before month
                result = ResultString(bankTest.CheckDebitCostBeforeMonth(), "CheckDebitCostBeforeMonth");
                Console.WriteLine(result);
                // Check credit cost before month
                result = ResultString(bankTest.CheckCreditCostBeforeMonth(), "CheckCreditCostBeforeMonth");
                Console.WriteLine(result);
                // Check debit cost after month
                result = ResultString(bankTest.CheckDebitCostAfterMonth(), "CheckDebitCostAfterMonth");
                Console.WriteLine(result);
                // Check credit cost after month
                result = ResultString(bankTest.CheckCreditCostAfterMonth(), "CheckCreditCostAfterMonth");
                Console.WriteLine(result);
            }
            catch (BankException ex)
            {
                Console.WriteLine($"ERROR DURING TESTS: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong...");
            }

            Console.ReadKey();
        }

        public static string ResultString(bool result, string testName)
        {
            return $"TEST {testName} WITH RESULT: {result}";
        }
    }
}

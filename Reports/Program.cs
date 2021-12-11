using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6_Report.Tests;

namespace Task6_Report
{
    class Program
    {
        static void Main(string[] args)
        {
            ReportTest reportTest = new ReportTest();
            try
            {
                string result = ResultString(reportTest.CheckWorkHaveDone(), "CheckWorkHaveDone");
                Console.WriteLine(result);
                result = ResultString(reportTest.CheckOwnerIsSet(), "CheckOwnerIsSet");
                Console.WriteLine(result);
                result = ResultString(reportTest.CheckSprint(), "CheckSprint");
                Console.WriteLine(result);
            }
            catch (ReportException ex)
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

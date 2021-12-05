using Lab3.Models;
using System;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "Lab3.pdf";
            BackupController controller = new BackupController();
            controller.RevertSystem();
            controller.AddFiles(filePath);
            Backup backup1 = controller.CreateBackup(true);
            controller.CreateRestorePoint(backup1);
            BackupTest backupTest = new BackupTest(controller);
            try
            {
                // Check backup was created
                string result = ResultString(backupTest.CheckBackupWasCreated(), "CheckBackupWasCreated");
                Console.WriteLine(result);
                // Check backup was created
                result = ResultString(backupTest.CheckRestorePointsWasCreated(), "CheckRestorePointsWasCreated");
                Console.WriteLine(result);
                // Check backup was created
                controller.RevertSystem();
                result = ResultString(backupTest.CheckSystemWasReverted(), "CheckSystemWasReverted");
                Console.WriteLine(result);
            }
            catch (BackupException ex)
            {
                Console.WriteLine($"ERRORS DURING TESTS: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong...");
            }
        }
        public static string ResultString(bool result, string testName)
        {
            return $"TEST {testName} WITH RESULT: {result}";
        }
    }
}

using Lab3.Models;
using System;

namespace Lab3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = "InternshipPlan.pptx";
            BackupController controller = new BackupController();
            controller.AddFiles(filePath);
            Backup backup1 = controller.CreateBackup(true);
            controller.CreateRestorePoint(backup1);
            //controller.RevertSystem();
        }
    }
}

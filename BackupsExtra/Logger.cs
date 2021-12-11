using System;
using System.IO;
using Lab5.Models;

namespace Lab5
{
    public class Logger : ILogger
    {
        public void ConsoleNotificate(Backup backup)
        {
            Console.WriteLine($"Backup #{backup.ID} was created!");
        }

        public void FileNotificate(Backup backup)
        {
            using (StreamWriter writer = new StreamWriter($"Backup_{backup.ID}.log"))
            {
                writer.WriteLine($"Backup #{backup.ID} was created!");
            }
        }
    }
}

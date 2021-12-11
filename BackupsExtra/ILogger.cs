using Lab5.Models;

namespace Lab5
{
    public interface ILogger
    {
        void ConsoleNotificate(Backup backup);
        void FileNotificate(Backup backup);
    }
}

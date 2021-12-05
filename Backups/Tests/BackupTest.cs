using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Models;

namespace Lab3.Tests
{
    public class BackupTest
    {
        private readonly BackupController _backupController;

        public BackupTest(BackupController backupController)
        {
            _backupController = backupController;
        }

        public bool CheckBackupWasCreated()
        {
            var directoryList = Directory.GetDirectories(Directory.GetCurrentDirectory());
            if (directoryList.Length > 0 && directoryList[0].Contains("ProgramFiles"))
            {
                return true;
            }

            throw new BackupException("Error check backup was created");
        }

        public bool CheckRestorePointsWasCreated()
        {
            var directoryList = Directory.GetDirectories(Directory.GetCurrentDirectory());
            if (directoryList.Length > 0 && directoryList[1].Contains("ZipResult"))
            {
                return true;
            }

            throw new BackupException("Error check restore point was created");
        }

        public bool CheckSystemWasReverted()
        {
            var directoryList = Directory.GetDirectories(Directory.GetCurrentDirectory());
            bool flag = true;
            foreach (var dir in directoryList)
            {
                if (dir.Contains("ProgramFiles") || dir.Contains("ZipResult"))
                {
                    flag = false;
                }
            }

            if (flag)
            {
                return true;
            }

            throw new BackupException("Error check system was reverted");
        }
    }
}

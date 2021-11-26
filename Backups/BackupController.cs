using Lab3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab3
{
    public enum CommandToDelete
    {
        Count,
        Date,
        Size
    }
    public enum DeleteModificator
    {
        All,
        Any
    }
    public class BackupController
    {
        private List<string> _filePaths;
        private Dictionary<int, List<string>> _backupFiles;
        private int _backupID = 1;
        private List<Backup> _backups;
        private int _n = 0; // #1
        private int _seconds = 0; // #2
        private double _size = 0; // #3

        public BackupController()
        {
            _backups = new List<Backup>();
            _backupFiles = new Dictionary<int, List<string>>();
            _filePaths = new List<string>();
        }

        public void AddFiles(string filePath)
        {
            _filePaths.Add(filePath);
        }

        public void RevertFilePaths()
        {
            _filePaths.Clear();
        }

        // ! OK
        public Backup CreateBackup(bool isUnion) 
        {
            // Создание директории и копирование туда выбранных файлов
            string curPath = $"{Configuration.LOCAL_PATH}_{_backupID}";
            Directory.CreateDirectory(curPath);
            foreach (var f in _filePaths)
            {
                string FileName = HelpClass.MySubString(f, f.LastIndexOf(@"\") + 1,
                                    f.Length);
                File.Copy(f, $@"{curPath}\{FileName}");
            }

            List<FileData> files = new List<FileData>();
            foreach (var f in Directory.GetFiles(curPath))
            {
                FileInfo fileInfo = new FileInfo(f);
                files.Add(new FileData(f, fileInfo.Length, File.GetLastWriteTime(f)));
            }

            // Add to list
            _backupFiles.Add(_backupID, new List<string>(_filePaths));
            Backup resultBackup = new Backup(_backupID++, DateTime.Now, files, isUnion);
            _backups.Add(resultBackup);
            return resultBackup;
        }

        public void DeletePoints(Backup backup, List<CommandToDelete> cmds, DeleteModificator mod)
        {
            List<int> commands = new List<int>();
            foreach (var cmd in cmds)
            {
                switch (cmd)
                {
                    case CommandToDelete.Count:
                        commands.Add(1);
                        break;
                    case CommandToDelete.Date:
                        commands.Add(2);
                        break;
                    case CommandToDelete.Size:
                        commands.Add(3);
                        break;
                }
            }

            int id = backup.ID;

            List<int> ids = new List<int>(); // TODO: Исправить хуйню
            switch (mod)
            {
                case DeleteModificator.All:
                    ids = new List<int>(_backups[id].DeletePointsAllCombo(commands, _n,
                    DateTime.Now.AddSeconds(-_seconds), _size));
                    break;
                case DeleteModificator.Any:
                    ids = new List<int>(_backups[id].DeletePointsAnyCombo(commands, _n,
                    DateTime.Now.AddSeconds(-_seconds), _size));
                    break;
            }

            try
            {
                _backups[id].DeletePoints(ids);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                int idNotToDelete = Convert.ToInt32(
                        HelpClass.MySubString(ex.Message, ex.Message.IndexOf(':') + 1, ex.Message.Length));
                for (int i = 0; i < ids.Count; i++)
                {
                    if (ids[i] == idNotToDelete)
                    {
                        ids.Remove(ids[i]);
                        break;
                    }
                }
            }
            foreach (var i in ids)
            { // Удалить физические копии
                Regex pattern = new Regex($@"RestorePoint_{i}(\w*)");
                var files = Directory.GetFiles($"{Configuration.DESTINATION_PATH}_{id + 1}")
                                     .Where(path => pattern.IsMatch(path));
                foreach (var f in files)
                {
                    if (File.Exists(f))
                    {
                        File.Delete(f);
                    }
                }
            }
        }

        public void CreateRestorePoint(Backup backup)
        {
            int id = backup.ID;
            _backups[id].AddRestorePoint();
        }

        public void CreateIncRestorePoint(Backup backup)
        {
            int id = backup.ID;
            _backups[id].AddIncRestorePoint();
        }

        public void DeletePointsByCount(Backup backup, int count)
        {
            int id = backup.ID;
            var ids = _backups[id].DeletePointsByCount(id);
            try
            {
                _backups[id].DeletePoints(ids);
            }
            catch (Exception ex)
            {
                int idNotToDelete = Convert.ToInt32(
                    HelpClass.MySubString(ex.Message, ex.Message.IndexOf(':') + 1, ex.Message.Length));
                for (int i = 0; i < ids.Count; i++)
                {
                    if (ids[i] == idNotToDelete)
                    {
                        ids.Remove(ids[i]);
                        break;
                    }
                }
            }
            
            foreach (var i in ids)
            { // Удалить физические копии
                Regex pattern = new Regex($@"RestorePoint_{i}(\w*)");
                var files = Directory.GetFiles($"{Configuration.DESTINATION_PATH}_{id + 1}")
                                     .Where(path => pattern.IsMatch(path));
                foreach (var f in files)
                {
                    if (File.Exists(f))
                    {
                        File.Delete(f);
                    }
                }
            }
        }

        public void DeletePointsByDate(Backup backup, int seconds)
        {
            int id = backup.ID;
            var ids = _backups[id].DeletePointsByDate(
                    DateTime.Now.AddSeconds(-seconds)); // Для наглядности
            try
            {
                _backups[id].DeletePoints(ids);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                int idNotToDelete = Convert.ToInt32(
                    HelpClass.MySubString(ex.Message, ex.Message.IndexOf(':') + 1, ex.Message.Length));
                for (int i = 0; i < ids.Count; i++)
                {
                    if (ids[i] == idNotToDelete)
                    {
                        ids.Remove(ids[i]);
                        break;
                    }
                }
            }

            foreach (var i in ids)
            { // Удалить физические копии
                Regex pattern = new Regex($@"RestorePoint_{i}(\w*)");
                var files = Directory.GetFiles($"{Configuration.DESTINATION_PATH}_{id + 1}")
                                     .Where(path => pattern.IsMatch(path));
                foreach (var f in files)
                {
                    if (File.Exists(f))
                    {
                        File.Delete(f);
                    }
                }
            }
        }

        public void DeletePointsBySize(Backup backup, double kb)
        {
            int id = backup.ID;
            var ids = _backups[id].DeletePointsBySize(kb);
            try
            {
                _backups[id].DeletePoints(ids);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                int idNotToDelete = Convert.ToInt32(
                    HelpClass.MySubString(ex.Message, ex.Message.IndexOf(':') + 1, ex.Message.Length));
                for (int i = 0; i < ids.Count; i++)
                {
                    if (ids[i] == idNotToDelete)
                    {
                        ids.Remove(ids[i]);
                        break;
                    }
                }
            }

            foreach (var i in ids)
            { // Удалить физические копии
                Regex pattern = new Regex($@"RestorePoint_{i}(\w*)");
                var files = Directory.GetFiles($"{Configuration.DESTINATION_PATH}_{id + 1}")
                                     .Where(path => pattern.IsMatch(path));
                foreach (var f in files)
                {
                    if (File.Exists(f))
                    {
                        File.Delete(f);
                    }
                }
            }
        }

        public void RevertSystem()
        {
            Regex patternLocal = new Regex($@"(\w*){Configuration.LOCAL_PATH}(\w*)");
            var dirsProg = Directory.GetDirectories(Directory.GetCurrentDirectory())
                                .Where(path => patternLocal.IsMatch(path))
                                .ToList();
            foreach (var d in dirsProg)
            {
                if (Directory.Exists(d))
                {
                    Directory.Delete(d, true);
                }
            }

            Regex patternZip = new Regex($@"(\w*){Configuration.DESTINATION_PATH}(\w*)");
            var dirsZip = Directory.GetDirectories(Directory.GetCurrentDirectory())
                                .Where(path => patternZip.IsMatch(path))
                                .ToList();
            foreach (var d in dirsZip)
            {
                if (Directory.Exists(d))
                {
                    Directory.Delete(d, true);
                }
            }
        }

        // Help methods

        private int GetSelectedID(string sub)
            => Convert.ToInt32(HelpClass.MySubString(sub, sub.IndexOf("#") + 1, sub.IndexOf("|") - 1)) - 1;

    }
}

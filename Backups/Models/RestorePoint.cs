using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class RestorePoint
    {
        public int ID { get; set; }
        public bool IsFull { get; set; } // Полноценная или инкрементальная
        public DateTime CreationTime { get; set; }
        public double PointSize { get; set; }
        public List<FileData> Files { get; set; }

        public RestorePoint(int id, bool isFull, DateTime creationTime, double pointSize, List<FileData> files)
        {
            ID = id;
            IsFull = isFull;
            CreationTime = creationTime;
            PointSize = Math.Round(pointSize / 1024, 2); // to KB
            Files = new List<FileData>();
            Files.AddRange(files);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0.Models
{
    public class Lesson
    {
        public PairSchedule Schedule { get; set; }
        public Group Group { get; set; }
        public Teacher Teacher { get; set; }
        public int Classroom { get; set; }
    }
}

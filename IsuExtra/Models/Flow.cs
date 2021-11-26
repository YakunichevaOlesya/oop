using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab0.Models
{
    public class Flow // Поток на курсе
    {
        public List<Lesson> Lessons { get; set; }
        public List<Student> Students { get; set; }
        public int MaxStudentCount { get; set; }
        public Flow()
        {
            Lessons = new List<Lesson>();
            Students = new List<Student>();
            MaxStudentCount = 30;
        }

        public List<Student> GetStudents()
        {
            List<Student> result = new List<Student>();
            foreach (var lesson in Lessons) {
                result.AddRange(lesson.Group.Students);
            }

            return result;
        }

        public List<Lesson> GetMfLessons(MF mf)
        {
            return Lessons.Where(g => g.Group.GroupName.MegaFaculty == mf).ToList();
        }
    }
}

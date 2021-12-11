using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab0.Models
{
    public class Group
    {
        public GroupName GroupName { get; set; }
        public List<Student> Students { get; set; }
        public List<Lesson> Lessons { get; set; }

        public void PrintGroupSchedule()
        {
            for (int i = 1; i <= 14; i++) {
                List<Lesson> lessonsThisDay = Lessons.Where(l => l.Schedule.Day == i).ToList();
                if (lessonsThisDay.Count > 0) { Console.WriteLine($"DAY #{i}"); }
                foreach (var lesson in lessonsThisDay)
                {
                    Console.WriteLine($"Pair #{lesson.Schedule.PairNumber}");
                    Console.WriteLine($"Subject: {lesson.Teacher.Subject}");
                    Console.WriteLine($"Teacher: {lesson.Teacher.Name}");
                    Console.WriteLine($"Classroom #{lesson.Classroom}");
                }
                Console.WriteLine();
            }
        }
    }
}

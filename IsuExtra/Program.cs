using System;
using System.Collections.Generic;
using System.Linq;
using Lab0.Models;

namespace Lab0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IsuService isu = new IsuService();
            // Check group add
            Group group1 = isu.AddGroup(new GroupName() { X = 1, YY = 04 });
            Group group2 = isu.AddGroup(new GroupName() { X = 2, YY = 05 });
            Group group3 = isu.AddGroup(new GroupName() { X = 3, YY = 06 });
            // Check student add
            isu.AddStudent(group1, "Olesya");
            isu.AddStudent(group1, "Alisa");
            isu.AddStudent(group1, "Varvara");
            isu.AddStudent(group1, "Sveta");

            isu.AddStudent(group2, "Sanek");
            isu.AddStudent(group2, "Stepan");
            isu.AddStudent(group2, "Goshan");
            isu.AddStudent(group2, "Alexey");

            isu.AddStudent(group3, "Danil");
            isu.AddStudent(group3, "Liza");
            isu.AddStudent(group3, "Anna");
            isu.AddStudent(group3, "Nikita");

            // Check student getter
            Console.WriteLine(isu.GetStudent(0).Name); // ! Olesya
            // Check student find
            Console.WriteLine(isu.FindStudent("Varvara").Id); // ! 2
            // Check "FindStudents" func with arg as group name
            isu.PrintStudentList(isu.FindStudents(group1.GroupName)); // ! Olesya Alisa Varvara Sveta
            // Check "FindStudents" func with arg as course number 
            isu.PrintStudentList(isu.FindStudents(new CourseNumber() { Number = 2 })); // ! Sanek Stepan Goshan Leha
            // Check "FindGroup" func
            isu.PrintGroupList(isu.FindGroup(group3.GroupName)); // ! Danil Liza Anna Nikita
            // Check "FindGroups" func
            isu.PrintGroupsList(isu.FindGroups(new CourseNumber() { Number = 1 })); // ! M3104
            // Check "ChangeStudentGroup" func
            isu.ChangeStudentGroup(isu.Students.FirstOrDefault(s => s.Name == "Goshan"), group3);
            isu.PrintGroupList(group2);
            isu.PrintGroupList(group3);

            // OGNP 
            Console.WriteLine("-------------------------OGNP-------------------------");
            group1.Lessons = new List<Lesson>();
            for (int i = 1; i <= 5; i++) { // каждый день по 3 пары у ОР
                group1.Lessons.Add(new Lesson()
                {
                    Group = group1,
                    Teacher = new Teacher() { Name = "Oleg Romanovich", Subject = "OOP" },
                    Classroom = 112,
                    Schedule = new PairSchedule() { Day = i, PairNumber = 1 }
                });
                group1.Lessons.Add(new Lesson()
                {
                    Group = group1,
                    Teacher = new Teacher() { Name = "Oleg Romanovich", Subject = "OOP" },
                    Classroom = 112,
                    Schedule = new PairSchedule() { Day = i, PairNumber = 2 }
                });
                group1.Lessons.Add(new Lesson()
                {
                    Group = group1,
                    Teacher = new Teacher() { Name = "Oleg Romanovich", Subject = "OOP" },
                    Classroom = 112,
                    Schedule = new PairSchedule() { Day = i, PairNumber = 3 }
                });
            }
            group1.PrintGroupSchedule();
            Flow flow1 = new Flow();
            Flow flow2 = new Flow();
            Flow flow3 = new Flow();
            
            isu.OgnpService.AddNewFlow(isu.OgnpService.Courses.Find(c => c.Mf == MF.FTMI), flow1);
            isu.OgnpService.AddNewFlow(isu.OgnpService.Courses.Find(c => c.Mf == MF.FTMI), flow2);
            isu.OgnpService.AddNewFlow(isu.OgnpService.Courses.Find(c => c.Mf == MF.FTMI), flow3);
            // ! Flow 1
            isu.OgnpService.AddNewLesson(flow1, 
                new PairSchedule() {Day = 1, PairNumber = 1}, 
                new Teacher() {Subject = "Marketing", Name = "Natalia"}, 234);
            isu.OgnpService.AddNewLesson(flow1,
                new PairSchedule() { Day = 1, PairNumber = 2 },
                new Teacher() { Subject = "Marketing", Name = "Natalia" }, 234);
            isu.OgnpService.AddNewLesson(flow1,
                new PairSchedule() { Day = 2, PairNumber = 1 },
                new Teacher() { Subject = "Philosophy", Name = "Natalia" }, 236);
            isu.OgnpService.AddNewLesson(flow1,
                new PairSchedule() { Day = 2, PairNumber = 2 },
                new Teacher() { Subject = "Philosophy", Name = "Natalia" }, 236);

            // ! Flow 2
            isu.OgnpService.AddNewLesson(flow2,
                new PairSchedule() { Day = 3, PairNumber = 1 },
                new Teacher() { Subject = "Marketing", Name = "Natalia" }, 234);
            isu.OgnpService.AddNewLesson(flow2,
                new PairSchedule() { Day = 3, PairNumber = 2 },
                new Teacher() { Subject = "Marketing", Name = "Natalia" }, 234);
            isu.OgnpService.AddNewLesson(flow2,
                new PairSchedule() { Day = 4, PairNumber = 1 },
                new Teacher() { Subject = "Philosophy", Name = "Natalia" }, 236);
            isu.OgnpService.AddNewLesson(flow2,
                new PairSchedule() { Day = 4, PairNumber = 2 },
                new Teacher() { Subject = "Philosophy", Name = "Natalia" }, 236);

            // ! FLow 3
            isu.OgnpService.AddNewLesson(flow3,
                new PairSchedule() { Day = 5, PairNumber = 4 },
                new Teacher() { Subject = "Marketing", Name = "Natalia" }, 234);
            isu.OgnpService.AddNewLesson(flow3,
                new PairSchedule() { Day = 5, PairNumber = 4 },
                new Teacher() { Subject = "Marketing", Name = "Natalia" }, 234);
            isu.OgnpService.AddNewLesson(flow3,
                new PairSchedule() { Day = 6, PairNumber = 5 },
                new Teacher() { Subject = "Philosophy", Name = "Natalia" }, 236);
            isu.OgnpService.AddNewLesson(flow3,
                new PairSchedule() { Day = 6, PairNumber = 5 },
                new Teacher() { Subject = "Philosophy", Name = "Natalia" }, 236);

            // ADD STUDENT
            isu.OgnpService.AddStudentToOgnp(group1.Students[0], 
                isu.OgnpService.Courses.Find(c => c.Mf == MF.FTMI));

        }
    }
}

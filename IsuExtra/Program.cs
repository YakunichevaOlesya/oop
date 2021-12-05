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
            Group group1 = isu.AddGroup(new GroupName() { X = 1, YY = 04 });
            Group group2 = isu.AddGroup(new GroupName() { X = 2, YY = 05 });
            Group group3 = isu.AddGroup(new GroupName() { X = 3, YY = 06 });

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

            group1.Lessons = new List<Lesson>();
            for (int i = 1; i <= 5; i++)
            { // каждый день по 3 пары у ОР
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
            // OGNP
            Flow flow1 = new Flow();
            Flow flow2 = new Flow();
            Flow flow3 = new Flow();

            isu.OgnpService.AddNewFlow(isu.OgnpService.Courses.Find(c => c.Mf == MF.FTMI), flow1);
            isu.OgnpService.AddNewFlow(isu.OgnpService.Courses.Find(c => c.Mf == MF.FTMI), flow2);
            isu.OgnpService.AddNewFlow(isu.OgnpService.Courses.Find(c => c.Mf == MF.FTMI), flow3);
            // ! Flow 1
            isu.OgnpService.AddNewLesson(flow1,
                new PairSchedule() { Day = 1, PairNumber = 1 },
                new Teacher() { Subject = "Marketing", Name = "Natalia" }, 234);
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

            IsuExtraServiceTest isuTest = new IsuExtraServiceTest(isu);

            try
            {
                // Check student getter
                string result = ResultString(isuTest.CheckStudentGetter(0), "CheckStudentGetter");
                Console.WriteLine(result);
                // Check student find
                result = ResultString(isuTest.CheckStudentFinder("Varvara"), "CheckStudentFinder");
                Console.WriteLine(result);
                // Check "FindStudents" func with arg as group name
                result = ResultString(isuTest.CheckFindStudentsByGroupName(group1.GroupName),
                    "CheckFindStudentsByGroupName");
                Console.WriteLine(result);
                // Check "FindStudents" func with arg as course number
                result = ResultString(isuTest.CheckFindStudentsByCourseNumber(new CourseNumber {Number = 2}),
                    "CheckFindStudentsByCourseNumber");
                Console.WriteLine(result);
                // Check "FindGroup" func
                result = ResultString(isuTest.CheckFindGroupByGroupName(group3.GroupName),
                    "CheckFindGroupByGroupName");
                Console.WriteLine(result);
                // Check "FindGroups" func
                result = ResultString(isuTest.CheckFindGroupsByCourseNumber(new CourseNumber {Number = 1}),
                    "CheckFindGroupsByCourseNumber");
                Console.WriteLine(result);
                // Check "ChangeStudentGroup" func
                result = ResultString(isuTest.TransferStudentToAnotherGroup_GroupChanged(),
                    "TransferStudentToAnotherGroup_GroupChanged");
                Console.WriteLine(result);
                // Check flows were added
                result = ResultString(isuTest.CheckFlowsWereAdded(),
                    "CheckFlowsWereAdded");
                Console.WriteLine(result);
                // Check lessons were added
                result = ResultString(isuTest.CheckLessonsWereAdded(),
                    "CheckLessonsWereAdded");
                Console.WriteLine(result);
                // Check student was added to ognp group
                result = ResultString(isuTest.CheckStudentWasAddedToOgnpGroup(),
                    "CheckStudentWasAddedToOgnpGroup");
                Console.WriteLine(result);
            }
            catch (IsuServiceException ex)
            {
                Console.WriteLine($"SOME TESTS GONE WRONG: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something gone wrong...");
            }
        }

        public static string ResultString(bool result, string testName)
        {
            return $"TEST {testName} WITH RESULT: {result}";
        }
    }
}

using System;
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
        }
    }
}

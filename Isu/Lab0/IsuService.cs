using System;
using System.Collections.Generic;
using System.Linq;
using Lab0.Models;

namespace Lab0
{
    public class IsuService : IIsuService
    {
        private int _studentId;
        public int MaxPeopleGroup { get; set; }
        public List<Group> Groups { get; set; } // Все группы в универе
        public List<Student> Students { get; set; } // Все студенты в универе

        public IsuService()
        {
            _studentId = 0;
            MaxPeopleGroup = 5;
            Groups = new List<Group>();
            Students = new List<Student>();
        }
        public Group AddGroup(GroupName name)
        {
            Groups.Add(new Group() { GroupName = name, Students = new List<Student>() });
            return Groups.LastOrDefault();
        }

        public Student AddStudent(Group group, string name)
        {
            Student newStudent = new Student() {Id = _studentId++, Name = name, Group = group};
            Students.Add(newStudent);
            group.Students.Add(newStudent);
            return newStudent;
        }

        public Student GetStudent(int id)
        {
            return Students.FirstOrDefault(s => s.Id == id);
        }

        public Student FindStudent(string name)
        {
            return Students.FirstOrDefault(s => s.Name == name);
        }

        public List<Student> FindStudents(GroupName groupName)
        {
            return FindGroup(groupName)?.Students;
        }

        public List<Student> FindStudents(CourseNumber courseNumber)
        {
            return Students.Where(g => g.Group.GroupName.X == courseNumber.Number).ToList();
        }

        public Group FindGroup(GroupName groupName)
        {
            return Groups.FirstOrDefault(g => g.GroupName.ToString() == groupName.ToString());
        }

        public List<Group> FindGroups(CourseNumber courseNumber)
        {
            return Groups.Where(g => g.GroupName.X == courseNumber.Number).ToList();
        }

        public void ChangeStudentGroup(Student student, Group newGroup)
        {
            student.Group.Students.Remove(student);
            newGroup.Students.Add(student);
        }

        public void PrintGroupList(Group group)
        {
            Console.WriteLine("Students of group " + group.GroupName.ToString() + ":");
            foreach (Student student in group.Students) {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine("------------------END------------------");
        }
        
        public void PrintStudentList(List<Student> students)
        {
            Console.WriteLine("STUDENT LIST:");
            foreach (var student in students) {
                Console.WriteLine(student.Name);
            }
            Console.WriteLine("------------------END------------------");
        }
        public void PrintGroupsList(List<Group> groups)
        {
            Console.WriteLine("GROUP LIST:");
            foreach (var group in groups)
            {
                Console.WriteLine(group.GroupName.ToString());
            }
            Console.WriteLine("------------------END------------------");
        }
    }
}

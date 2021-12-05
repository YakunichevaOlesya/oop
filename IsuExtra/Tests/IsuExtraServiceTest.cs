using System;
using System.Collections.Generic;
using System.Linq;
using Lab0.Models;

namespace Lab0.Tests
{
    public class IsuExtraServiceTest
    {
        private readonly IIsuService _isu;

        public IsuExtraServiceTest(IIsuService isu)
        {
            _isu = isu;
        }

        public bool CheckStudentGetter(int studentId)
        {
            if (_isu.GetStudent(0).Name == "Olesya")
            {
                return true;
            }

            throw new IsuServiceException("Error student getter!");
        }

        public bool CheckStudentFinder(string studentName)
        {
            if (_isu.FindStudent(studentName).Id == 2)
            {
                return true;
            }

            throw new IsuServiceException("Error student finder!");
        }

        public bool CheckFindStudentsByGroupName(GroupName groupName)
        {
            List<Student> students = _isu.FindStudents(groupName);
            if (students.Count == 4) // ! Olesya Alisa Varvara Sveta
            {
                return true;
            }

            throw new IsuServiceException("Error in find students by groupname");
        }

        public bool CheckFindStudentsByCourseNumber(CourseNumber course)
        {
            List<Student> students = _isu.FindStudents(course);
            if (students.Count == 4) // ! Sanek Stepan Goshan Leha
            {
                return true;
            }

            throw new IsuServiceException("Error in find students by course number");
        }

        public bool CheckFindGroupByGroupName(GroupName groupName)
        {
            Group group = _isu.FindGroup(groupName);
            if (group.Students.Count == 4) // ! Danil Liza Anna Nikita
            {
                return true;
            }

            throw new IsuServiceException("Error in find group by group name");
        }

        public bool CheckFindGroupsByCourseNumber(CourseNumber course)
        {
            List<Group> groups = _isu.FindGroups(course);
            if (groups.Count == 1) // ! M3104
            {
                return true;
            }

            throw new IsuServiceException("Error in find groups by course number");
        }

        public bool TransferStudentToAnotherGroup_GroupChanged()
        {
            Group group1 = _isu.AddGroup(new GroupName() { X = 1, YY = 6 });
            Group group2 = _isu.AddGroup(new GroupName() { X = 1, YY = 9 });
            Student student = _isu.AddStudent(group1, "Misha");
            _isu.ChangeStudentGroup(student, group2);
            if (!group1.Students.Contains(student) && group2.Students.Contains(student))
            {
                return true;
            }
            throw new IsuServiceException("Student group has not been changed!");
        }

        public bool CheckFlowsWereAdded()
        {
            if (_isu.OgnpService.Courses.FirstOrDefault(c => c.Mf == MF.FTMI)?.Flows.Count == 3)
            {
                return true;
            }

            throw new IsuServiceException("Check flows where added error");
        }

        public bool CheckLessonsWereAdded()
        {
            if (_isu.OgnpService.Courses.FirstOrDefault(c => c.Mf == MF.FTMI)?.Flows[0].Lessons.Count == 4)
            {
                return true;
            }

            throw new IsuServiceException("Check lessons were added error");
        }

        public bool CheckStudentWasAddedToOgnpGroup()
        {
            var olesyaStudent = _isu.GetStudent(0);
            if (_isu.OgnpService.AddStudentToOgnp(olesyaStudent,
                _isu.OgnpService.Courses.Find(c => c.Mf == MF.FTMI)))
            {
                return true;
            }

            throw new IsuServiceException("Student was not added to Ognp group");
        }
    }
}

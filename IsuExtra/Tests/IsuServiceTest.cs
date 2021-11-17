using System;
using System.Collections.Generic;
using Lab0.Models;

namespace Lab0.Tests
{
    public class IsuServiceTest
    {
        public IsuService Isu { get; set; }
        [Test]
        public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
        {
            Group group = Isu.AddGroup(new GroupName() { X = 1, YY = 11 });
            Student student = Isu.AddStudent(group, "Olesich");
            if (student.Group != group || !group.Students.Contains(student)) {
                throw new IsuServiceException("Student is not in group OR group does not contain student");
            }
        }

        [Test]
        public void ReachMaxStudentPerGroup_ThrowException()
        {
            Group group = Isu.AddGroup(new GroupName() {X = 2, YY = 12});
            for (int i = 0; i < 10; i++) {
                if (group.Students.Count > Isu.MaxPeopleGroup) {
                    throw new IsuServiceException("Too many students in one group!");
                }
                Isu.AddStudent(@group, i.ToString());
            }
        }

        [Test]
        public void CreateGroupWithInvalidName_ThrowException()
        {
            List<GroupName> groupNames = new List<GroupName>();
            for (int i = 1; i <= 15; i++) {
                GroupName groupName = new GroupName() {X = i, YY = i};
                if (groupName.X < 1 || groupName.X > 4 || groupName.YY < 1 || groupName.YY > 14) {
                    throw new IsuServiceException("Invalid group name!");
                }
                groupNames.Add(groupName);
            }
        }

        [Test]
        public void TransferStudentToAnotherGroup_GroupChanged()
        {
            Group group1 = Isu.AddGroup(new GroupName() {X = 1, YY = 6});
            Group group2 = Isu.AddGroup(new GroupName() { X = 1, YY = 9 });
            Student student = Isu.AddStudent(group1, "Misha");
            Isu.ChangeStudentGroup(student, group2);
            if (group1.Students.Contains(student) || !group2.Students.Contains(student)) {
                throw new IsuServiceException("Student group has not been changed!");
            }
        }
    }
    public class TestAttribute : Attribute { } // Заглушка для того чтобы объявить атрибут
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab0.Models;

namespace Lab0
{
    public interface IOgnpService
    {
        public void AddNewFlow(OgnpCourse course, Flow flow);

        public void AddNewLesson(Flow flow, PairSchedule schedule, Teacher teacher, int classRoom);

        public bool AddStudentToOgnp(Student student, OgnpCourse ognp);

        public bool DeleteStudentFromOgnp(Student student, OgnpCourse ognp);

        public List<Flow> GetFlows(OgnpCourse ognp);

        public List<Student> GetStudentsFromOgnpGroup(Group ognpGroup);

        public List<Student> GetStudentsWithoutOgnp(List<Student> allStudents);
    }
}

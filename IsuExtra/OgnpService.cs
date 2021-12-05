using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab0.Models;

namespace Lab0
{
    public class OgnpService : IOgnpService
    {
        public List<OgnpCourse> Courses { get; set; }

        public OgnpService()
        {
            Courses = new List<OgnpCourse>();

            Courses.Add(new OgnpCourse() { Flows = new List<Flow>(), Mf = MF.TINT });
            Courses.Add(new OgnpCourse() { Flows = new List<Flow>(), Mf = MF.FTMI });
            Courses.Add(new OgnpCourse() {Flows = new List<Flow>(), Mf = MF.BTINS});
            Courses.Add(new OgnpCourse() { Flows = new List<Flow>(), Mf = MF.FTMF });
            Courses.Add(new OgnpCourse() { Flows = new List<Flow>(), Mf = MF.KTU });
        }

        public void AddNewFlow(OgnpCourse course, Flow flow)
        {
            course.Flows.Add(flow);
        }

        public void AddNewLesson(Flow flow, PairSchedule schedule, Teacher teacher, int classRoom)
        {
            flow.Lessons.Add(new Lesson() {
                Schedule = schedule,
                Teacher = teacher,
                Classroom = classRoom
            });
        }

        public bool AddStudentToOgnp(Student student, OgnpCourse course)
        {
            if (student.Group.GroupName.MegaFaculty == course.Mf) { return false; }
            if (student.OgnpGroup == null) {
                List<Lesson> studentLessons = student.Group.Lessons;
                foreach (Flow courseFlow in course.Flows) { // Идём по всем потокам
                    List<Lesson> flowLessons = courseFlow.Lessons; // берём пары потока
                    bool exitLoop = false;
                    foreach (var flowLesson in flowLessons) { // идём по всем парам потока
                        foreach (var studentLesson in studentLessons) { // идём по всем парам студента
                            if (studentLesson.Schedule == flowLesson.Schedule) { // если хоть 1 пара пересекается то выходим из цикла
                                exitLoop = true;
                            }

                            if (exitLoop) { break; }
                        }
                        if (exitLoop) { break; }
                    }

                    if (!exitLoop) {
                        if (courseFlow.Students.Count >= courseFlow.MaxStudentCount) { return false; }
                        courseFlow.Students.Add(student);
                        student.OgnpGroup = courseFlow;
                        Console.WriteLine($"Студент {student.Name} записался на ОГНП мегафакультета {course.Mf}" +
                                          $" на поток №{course.Flows.IndexOf(courseFlow) + 1}");
                        return true;
                    }
                }
            }

            return false;
        }

        public bool DeleteStudentFromOgnp(Student student, OgnpCourse course)
        {
            Flow flow = student.OgnpGroup;
            student.OgnpGroup = null;
            flow.Students.Remove(student);
            return true;
        }

        public List<Flow> GetFlows(OgnpCourse ognp)
        {
            return ognp.Flows;
        }

        public List<Student> GetStudentsFromOgnpGroup(Group ognpGroup)
        {
            return ognpGroup.Students;
        }

        public List<Student> GetStudentsWithoutOgnp(List<Student> allStudents)
        {
            List<Student> result = new List<Student>();
            foreach (var student in allStudents) {
                if (student.OgnpGroup == null) {
                    result.Add(student);
                }
            }

            return result;
        }
    }
}

using SchoolERP.Business.Services.Interfaces;
using SchoolERP.Core.Models;
using SchoolERP.Data.DAL;

namespace SchoolERP.Business.Services.Implementations
{
    public class TeacherService : ITeacherService
    {
        public void Create(Teacher teacher)
        {
            SchoolERPDatabase.Teachers.Add(teacher); 
        }

        public Teacher Get(int id)
        {
            Teacher? wantedTeacher = SchoolERPDatabase.Teachers.Find(x => x.Id == id);

            if (wantedTeacher != null)
            {
                return wantedTeacher;
            }
            else 
            { 
                throw new NullReferenceException("Teacher not found!");
            }
        }

        public List<Teacher> GetAll()
        {
            return SchoolERPDatabase.Teachers;
        }

        public void Remove(int id)
        {
            Teacher? wantedTeacher = SchoolERPDatabase.Teachers.Find(x => x.Id == id);


            if(wantedTeacher != null)
            {
                List<Student> wantedStudents = SchoolERPDatabase.Students.FindAll(x => x.TeacherId == id);
                wantedStudents.ForEach(x => x.Teacher = null);
                wantedTeacher.Students.Clear();
                SchoolERPDatabase.Teachers.Remove(wantedTeacher);
            }
            else
            {
                throw new NullReferenceException("Teacher could not be removed!");
            }
        }
    }
}

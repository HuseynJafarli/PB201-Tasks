using SchoolERP.Business.Services.Interfaces;
using SchoolERP.Core.Models;
using SchoolERP.Data.DAL;

namespace SchoolERP.Business.Services.Implementations
{
    public class StudentService : IStudentService
    {
        public void Create(Student student)
        {
            SchoolERPDatabase.Students.Add(student);
            Teacher modifiedTeacher = SchoolERPDatabase.Teachers.Find(x => x.Id == student.TeacherId);
            if (modifiedTeacher != null) 
            {
                modifiedTeacher.Students.Add(student);
            }         
        }

        public Student Get(int id)
        {
            Student? wantedStudent = SchoolERPDatabase.Students.Find(x => x.Id == id);
            if (wantedStudent != null)
            {
                return wantedStudent;
            }
            else
            {
                throw new NullReferenceException("Student not found");
            }

        }

        public List<Student> GetAll()
        {
            return SchoolERPDatabase.Students;
        }

        public void Remove(int id)
        {
            Student? wantedStudent = SchoolERPDatabase.Students.Find(x => x.Id == id);
            Teacher modifiedTeacher = SchoolERPDatabase.Teachers.Find(x => x.Id == wantedStudent.TeacherId);


            if (wantedStudent != null && modifiedTeacher != null)
            {
                SchoolERPDatabase.Students.Remove(wantedStudent);
                modifiedTeacher?.Students.Remove(wantedStudent);
            }
            else
            {
                throw new NullReferenceException("Student could not be removed!");
            }
        }
    }
}

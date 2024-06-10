using GroupERP.Business.Services.Interfaces;
using GroupERP.Core.Models;
using GroupERP.Data.DAL;


namespace GroupERP.Business.Services.Implementations
{
    public class StudentServices : IStudentServices
    {
        public void Create(Student student)
        {
            GroupData.Students.Add(student);



        }

        public Student Get(int id)
        {
            Student? wantedStd = GroupData.Students.Find(x => x.Id == id);
            if (wantedStd != null)
            {
                return wantedStd;
            }
            else
            {
                throw new NullReferenceException("Student could not be found!");
            }
        }

        public List<Student> GetAll()
        {
            return GroupData.Students;
        }

        public void Remove(int id)
        {
            Student? wantedStudent = GroupData.Students.Find(x => x.Id == id);

            Group? updatedGrp = GroupData.Groups.Find(x => x.Id == wantedStudent.Group?.Id);


            if (wantedStudent != null)
            {
                if (updatedGrp != null)
                {
                    updatedGrp?.Students.Remove(wantedStudent);
                }
                GroupData.Students.Remove(wantedStudent);
            }
            else
            {
                throw new NullReferenceException("Student with Id you provided could not be found to remove!");
            }
        }
    }
}
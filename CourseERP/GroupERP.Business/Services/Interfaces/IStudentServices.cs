using GroupERP.Core.Models;

namespace GroupERP.Business.Services.Interfaces
{
    public interface IStudentServices
    {
        void Create(Student student);

        List<Student> GetAll();

        Student Get(int id);
        void Remove(int id);
    }
}
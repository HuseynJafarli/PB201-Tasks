using SchoolERP.Core.Models;

namespace SchoolERP.Business.Services.Interfaces
{
    public interface ITeacherService
    {
        void Create(Teacher teacher);

        List<Teacher> GetAll();

        Teacher Get(int id);
        void Remove(int id);
    }
}

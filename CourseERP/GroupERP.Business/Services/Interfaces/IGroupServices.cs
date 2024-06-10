using GroupERP.Core.Models;

namespace GroupERP.Business.Services.Interfaces
{
    public interface IGroupServices
    {
        void Create(Group group);

        List<Group> GetAll();

        Group Get(int id);
        void Remove(int id);
    }
}
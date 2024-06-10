using GroupERP.Business.Services.Interfaces;
using GroupERP.Core.Models;
using GroupERP.Data.DAL;


namespace GroupERP.Business.Services.Implementations
{
    public class GroupServices : IGroupServices
    {
        public void Create(Group group)
        {
            GroupData.Groups.Add(group);
        }

        public Group Get(int id)
        {
            Group? wantedGrp = GroupData.Groups.Find(x => x.Id == id);
            if (wantedGrp != null)
            {
                return wantedGrp;
            }
            else
            {
                throw new NullReferenceException("Group could not be found!");
            }
        }

        public List<Group> GetAll()
        {
            return GroupData.Groups;
        }

        public void Remove(int id)
        {
            Group wantedGrp = Get(id);

            if (wantedGrp != null)
            {
                List<Student> removeGrpFrom = GroupData.Students.FindAll(x => x.Group.Id == id);
                removeGrpFrom.ForEach(x => x.Group = null);
                wantedGrp.Students.Clear();
                GroupData.Groups.Remove(wantedGrp);
            }
            else
            {
                throw new NullReferenceException("Group could not be removed!");
            }
        }
    }
}
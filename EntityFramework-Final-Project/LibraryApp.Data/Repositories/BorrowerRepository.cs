using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories;

namespace LibraryApp.Data.Repositories
{
    public class BorrowerRepository: GenericRepository<Borrower>, IBorrowerRepository
    {
    }
}

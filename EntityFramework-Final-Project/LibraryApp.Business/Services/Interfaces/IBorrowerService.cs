using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Services.Interfaces
{
    public interface IBorrowerService
    {
        List<Borrower> GetAllBorrowers();
        Task CreateBorrowerAsync(Borrower borrower);
        Task UpdateBorrowerAsync(Borrower borrower);
        Task DeleteBorrowerAsync(int borrowerId);
    }
}

using LibraryApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Business.Services.Interfaces
{
    public interface ILoanService
    {
        Task BorrowBookAsync(int borrowerId, int bookId);
        Task ReturnBookAsync(int loanId, DateTime returnDate);
        Task<Book> GetMostBorrowedBookAsync();
        Task<List<Borrower>> GetOverdueBorrowersAsync();
        Task<Dictionary<Borrower, List<Book>>> GetBooksBorrowedByBorrowersAsync();
    }
}

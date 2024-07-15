using LibraryApp.Business.Services.Interfaces;
using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories;
using LibraryApp.Data.Repositories;

namespace LibraryApp.Business.Services.Implementations
{
    public class LoanService : ILoanService
    {
        private ILoanRepository _loanRepository;

        public LoanService()
        {
            _loanRepository = new LoanRepository();
        }

        public Task BorrowBookAsync(int borrowerId, int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<Dictionary<Borrower, List<Book>>> GetBooksBorrowedByBorrowersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetMostBorrowedBookAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Borrower>> GetOverdueBorrowersAsync()
        {
            throw new NotImplementedException();
        }

        public Task ReturnBookAsync(int loanId, DateTime returnDate)
        {
            throw new NotImplementedException();
        }
    }
}

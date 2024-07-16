using LibraryApp.Business.Services.Interfaces;
using LibraryApp.Core.Models;
using LibraryApp.Core.Repositories;
using LibraryApp.Data.Repositories;

namespace LibraryApp.Business.Services.Implementations
{
    public class BorrowerService : IBorrowerService
    {
        private IBorrowerRepository _borrowerRepository;

        public BorrowerService()
        {
            _borrowerRepository = new BorrowerRepository();
        }

        public List<Borrower> GetAllBorrowers()
        {
            return _borrowerRepository.GetAll().ToList();
        }

        public async Task CreateBorrowerAsync(Borrower borrower)
        {
            await _borrowerRepository.Insert(borrower);
            await _borrowerRepository.CommitAsync();
        }

        public async Task UpdateBorrowerAsync(Borrower borrower)
        {
            var existData = await _borrowerRepository.GetAsync(borrower.Id);
            if (existData != null)
            {
                existData.Name = borrower.Name;
                existData.Email = borrower.Email;
            }
        }

        public async Task DeleteBorrowerAsync(int borrowerId)
        {
            var borrower = await _borrowerRepository.GetAsync(borrowerId);
            if (borrower != null)
            {
                _borrowerRepository.Delete(borrower);
                await _borrowerRepository.CommitAsync();
            }
            else
            {
                Console.WriteLine("Id dont exist!");
            }
        }
    }

}

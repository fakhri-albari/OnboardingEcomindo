using OnboardingEcomindo.DAL.Models;
using OnboardingEcomindo.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnboardingEcomindo.BLL
{
    public class TransactionService
    {
        private readonly UnitOfWork _unitOfWork;

        public TransactionService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _unitOfWork.TransactionRepo.GetAll();
        }

        public async Task<Transaction> GetById(int id)
        {
            return await _unitOfWork.TransactionRepo.GetById(id);
        }

        public async Task<Transaction> Add(Transaction transaction)
        {
            return await _unitOfWork.TransactionRepo.Add(transaction);
        }

        public async Task Update(Transaction transaction)
        {
            await _unitOfWork.TransactionRepo.Update(transaction);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.TransactionRepo.Delete(id);
        }
    }
}

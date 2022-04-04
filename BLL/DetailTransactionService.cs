using OnboardingEcomindo.DAL.Models;
using OnboardingEcomindo.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnboardingEcomindo.BLL
{
    public class DetailTransactionService
    {
        private readonly UnitOfWork _unitOfWork;

        public DetailTransactionService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DetailTransaction>> GetAll()
        {
            return await _unitOfWork.DetailTransactionRepo.GetAll();
        }

        public async Task<DetailTransaction> GetById(int id)
        {
            return await _unitOfWork.DetailTransactionRepo.GetById(id);
        }

        public async Task<DetailTransaction> Add(DetailTransaction detailTransaction)
        {
            return await _unitOfWork.DetailTransactionRepo.Add(detailTransaction);
        }

        public async Task Update(DetailTransaction detailTransaction)
        {
            await _unitOfWork.DetailTransactionRepo.Update(detailTransaction);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.DetailTransactionRepo.Delete(id);
        }
    }
}

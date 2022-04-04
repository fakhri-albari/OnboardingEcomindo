using OnboardingEcomindo.DAL.Models;
using OnboardingEcomindo.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnboardingEcomindo.BLL
{
    public class CashierService
    {
        private readonly UnitOfWork _unitOfWork;

        public CashierService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Cashier>> GetAll()
        {
            return await _unitOfWork.CashierRepo.GetAll();
        }

        public async Task<Cashier> GetById(int id)
        {
            return await _unitOfWork.CashierRepo.GetById(id);
        }

        public async Task<Cashier> Add(Cashier cashier)
        {
            return await _unitOfWork.CashierRepo.Add(cashier);
        }

        public async Task Update(Cashier cashier)
        {
            await _unitOfWork.CashierRepo.Update(cashier);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.CashierRepo.Delete(id);
        }
    }
}

using Microsoft.EntityFrameworkCore.Storage;
using OnboardingEcomindo.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnboardingEcomindo.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Item> ItemRepo { get; }
        IGenericRepository<Cashier> CashierRepo { get; }
        IGenericRepository<Transaction> TransactionRepo { get; }
        IGenericRepository<DetailTransaction> DetailTransactionRepo { get; }
    }
}

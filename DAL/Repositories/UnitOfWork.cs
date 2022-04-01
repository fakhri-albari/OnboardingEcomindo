using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnboardingEcomindo.DAL.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnboardingEcomindo.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Item> ItemRepo { get; }

        public IGenericRepository<Cashier> CashierRepo { get; }

        public IGenericRepository<Transaction> TransactionRepo { get; }

        public IGenericRepository<DetailTransaction> DetailTransactionRepo { get; }

        public UnitOfWork(MetaShopContext context)
        {
            ItemRepo = new GenericRepository<Item>(context);
            CashierRepo = new GenericRepository<Cashier>(context);
            TransactionRepo = new GenericRepository<Transaction>(context);
            DetailTransactionRepo = new GenericRepository<DetailTransaction>(context);
        }

    }
}

using Microsoft.EntityFrameworkCore.Storage;
using OnboardingEcomindo.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnboardingEcomindo.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Item> ItemRepository { get; }
        void Save();
        Task SaveAsync(CancellationToken cancellationToken = default(CancellationToken));
        IDbContextTransaction StartNewTransaction();
        Task<IDbContextTransaction> StartNewTransactionAsync();
        Task<int> ExecuteSqlCommandAsync(string sql, object[] parameters, CancellationToken cancellationToken = default(CancellationToken));
    }
}

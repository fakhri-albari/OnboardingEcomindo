using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace OnboardingEcomindo.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        T Add(T entity);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        void Edit(T entity);
        void Delete(T entity);
        IQueryable<T> GetAll();
        Task GetByIdAsync(int id);
    }
}

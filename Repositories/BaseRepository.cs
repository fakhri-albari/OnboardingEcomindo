using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace OnboardingEcomindo.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> dbSet;

        public DbContext Context { get; private set; }

        public BaseRepository(DbContext dbContext)
        {
            Context = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public T Add(T entity)
        {
            T result = dbSet.Add(entity).Entity;
            Console.WriteLine(result);
            return result;
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<T> entry = await dbSet.AddAsync(entity, cancellationToken);
            return entry.Entity;
        }

        public void Edit(T entity)
        {
            dbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
    }
}

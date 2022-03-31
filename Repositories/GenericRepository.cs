using Microsoft.EntityFrameworkCore;
using OnboardingEcomindo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnboardingEcomindo.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> dbSet;

        public DbContext _context { get; set; }

        public GenericRepository(MetaShopContext context) 
        { 
            _context = context;
            dbSet = context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            T result = dbSet.Add(entity).Entity;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entityToDelete = await dbSet.FindAsync(id);
            if (entityToDelete != null) {
                dbSet.Remove(entityToDelete);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToArrayAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }
    }
}

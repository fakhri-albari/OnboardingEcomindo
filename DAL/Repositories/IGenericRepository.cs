using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnboardingEcomindo.DAL.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}

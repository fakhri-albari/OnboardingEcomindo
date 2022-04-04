using System.Threading.Tasks;

namespace OnboardingEcomindo.BLL.Cache
{
    interface IRedisService
    {
        Task SaveAsync(string key, object value);
        Task<T> GetAsync<T>(string key);
        Task<bool> DeleteAsync(string key);
    }
}

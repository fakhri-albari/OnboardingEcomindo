using OnboardingEcomindo.BLL.Cache;
using OnboardingEcomindo.DAL.Models;
using OnboardingEcomindo.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnboardingEcomindo.BLL
{
    public class ItemService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly RedisService _redis;

        public ItemService(UnitOfWork unitOfWork, RedisService redis)
        {
            _unitOfWork = unitOfWork;
            _redis = redis;
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _unitOfWork.ItemRepo.GetAll();
        }

        public async Task<Item> GetById(int id)
        {
            Item item = await _redis.GetAsync<Item>($"item_itemId:{id}");

            if (item == null)
            {
                item = await _unitOfWork.ItemRepo.GetById(id);
                await _redis.SaveAsync($"item_itemId:{id}", item);
            }
            return item;
        }

        public async Task<Item> Add(Item item)
        {
            return await _unitOfWork.ItemRepo.Add(item);
        }

        public async Task Update(Item item)
        {
            await _unitOfWork.ItemRepo.Update(item);
        }

        public async Task Delete(int id)
        {
            await _unitOfWork.ItemRepo.Delete(id);
        }
    }
}

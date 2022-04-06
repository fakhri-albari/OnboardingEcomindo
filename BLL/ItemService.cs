using Microsoft.Extensions.Configuration;
using OnboardingEcomindo.BLL.Cache;
using OnboardingEcomindo.BLL.Messaging;
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
        private readonly MessageFactory _messageFactory;
        private readonly IConfiguration _config;

        public ItemService(UnitOfWork unitOfWork, IConfiguration? config, RedisService? redis, MessageFactory? messageFactory)
        {
            _unitOfWork = unitOfWork;
            _redis = redis;
            _messageFactory = messageFactory;
            _config = config;
        }

        public async Task<IEnumerable<Item>> GetAll()
        {
            return await _unitOfWork.ItemRepo.GetAll();
        }

        public async Task<Item> GetById(int id)
        {
            Item item = null;
            if (_redis != null)
            {
                item = await _redis.GetAsync<Item>($"item_itemId:{id}");
            }

            if (item == null)
            {
                item = await _unitOfWork.ItemRepo.GetById(id);

                if(_redis != null)
                {
                    await _redis.SaveAsync($"item_itemId:{id}", item);
                }
            }
            return item;
        }

        public async Task<Item> Add(Item item)
        {
            if (_config != null && _messageFactory != null)
            {
                await SendToEventHub(item);
            }
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

        private async Task SendToEventHub(Item data) {
            string topic = _config.GetValue<string>("EventHub:Topic");

            MessageSender message = _messageFactory.Create(_config, topic);

            await message.CreateEventBatchAsync();

            message.AddMessage(data);

            await message.SendMessage();
        }
    }
}

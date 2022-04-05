using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnboardingEcomindo.DAL.Models;
using OnboardingEcomindo.BLL.DTO;
using OnboardingEcomindo.DAL.Repositories;
using System.Collections.Generic;
using OnboardingEcomindo.BLL.Cache;
using OnboardingEcomindo.BLL;
using Microsoft.Extensions.Configuration;
using OnboardingEcomindo.BLL.Messaging;

namespace OnboardingEcomindo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemService _itemService;
        private readonly IMapper _mapper;

        public ItemsController(UnitOfWork unitOfWork, IConfiguration configuration, RedisService redis, MessageFactory messageFactory)
        {
            MapperConfiguration config = new MapperConfiguration(m =>
            {
                m.CreateMap<ItemsDTO, Item>();
                m.CreateMap<Item, ItemsDTO>();
            });

            _mapper = config.CreateMapper();
            _itemService = new ItemService(unitOfWork, configuration, redis, messageFactory);
        }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAll() {
            return await _itemService.GetAll();
        }

        /// <summary>
        /// Get Item Using ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<Item> GetById([FromRoute] int id)
        {
            return await _itemService.GetById(id);
        }

        /// <summary>
        /// Create Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Item> Post([FromBody] ItemsDTO itemDTO)
        {
            Item item = _mapper.Map<Item>(itemDTO);
            return await _itemService.Add(item);
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] ItemsDTO itemDTO)
        {
            Item item = _mapper.Map<Item>(itemDTO);
            item.ItemId = id;
            await _itemService.Update(item);
        }
        /// <summary>
        /// Delete item using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] int id) {
            await _itemService.Delete(id);
        }    
    }
}

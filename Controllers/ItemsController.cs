using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnboardingEcomindo.Models;
using OnboardingEcomindo.DTO;
using OnboardingEcomindo.Repositories;
using System.Collections.Generic;

namespace OnboardingEcomindo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ItemsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            MapperConfiguration config = new MapperConfiguration(m =>
            {
                m.CreateMap<ItemsDTO, Item>();
                m.CreateMap<Item, ItemsDTO>();
            });

            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Item>> GetAll() {
            return await _unitOfWork.ItemRepo.GetAll();
        }

        /// <summary>
        /// Get Item Using ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<Item> GetById([FromRoute] int id)
        {
            return await _unitOfWork.ItemRepo.GetById(id);
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
            return await _unitOfWork.ItemRepo.Add(item);
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
            await _unitOfWork.ItemRepo.Update(item);
        }
        /// <summary>
        /// Delete item using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] int id) {
            await _unitOfWork.ItemRepo.Delete(id);
        }    
    }
}

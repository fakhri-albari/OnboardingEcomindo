using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnboardingEcomindo.Models;
using OnboardingEcomindo.Repositories;
using Microsoft.Extensions.Logging;

namespace OnboardingEcomindo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        private readonly ILogger<ItemsController> _logger;

        public ItemsController(ILogger<ItemsController> logger, UnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var result = await _unitOfWork.ItemRepository.GetAll().ToListAsync();
            return new ObjectResult(result);
        }

        /// <summary>
        /// Get Item Using ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Item result = await _unitOfWork.ItemRepository.GetByIdAsync(id);
            return new ObjectResult(result);
        }

        /// <summary>
        /// Create Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public Item Post([FromBody] Item item)
        {
            var result = _unitOfWork.ItemRepository.Add(item);
            return result;
        }
    }
}

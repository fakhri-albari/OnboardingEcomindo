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
    public class CashiersController : ControllerBase
    {
        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CashiersController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            MapperConfiguration config = new MapperConfiguration(m =>
            {
                m.CreateMap<CashiersDTO, Cashier>();
                m.CreateMap<Cashier, CashiersDTO>();
            });

            _mapper = config.CreateMapper();
        }

        /// <summary>
        /// Get all cashiers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Cashier>> GetAll()
        {
            return await _unitOfWork.CashierRepo.GetAll();
        }

        /// <summary>
        /// Get cashier using ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<Cashier> GetById([FromRoute] int id)
        {
            return await _unitOfWork.CashierRepo.GetById(id);
        }

        /// <summary>
        /// Create Item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Cashier> Post([FromBody] CashiersDTO cashierDTO)
        {
            Cashier cashier = _mapper.Map<Cashier>(cashierDTO);
            return await _unitOfWork.CashierRepo.Add(cashier);
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] CashiersDTO cashiersDTO)
        {
            Cashier cashier = _mapper.Map<Cashier>(cashiersDTO);
            cashier.Id = id;
            await _unitOfWork.CashierRepo.Update(cashier);
        }

        /// <summary>
        /// Delete cashier using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _unitOfWork.CashierRepo.Delete(id);
        }
    }
}

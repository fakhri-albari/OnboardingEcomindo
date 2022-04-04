using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using OnboardingEcomindo.DAL.Models;
using OnboardingEcomindo.BLL.DTO;
using OnboardingEcomindo.DAL.Repositories;
using System.Collections.Generic;
using OnboardingEcomindo.BLL;

namespace OnboardingEcomindo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashiersController : ControllerBase
    {
        private readonly CashierService _cashierService;
        private readonly IMapper _mapper;

        public CashiersController(UnitOfWork unitOfWork)
        {
            MapperConfiguration config = new MapperConfiguration(m =>
            {
                m.CreateMap<CashiersDTO, Cashier>();
                m.CreateMap<Cashier, CashiersDTO>();
            });

            _mapper = config.CreateMapper();
            _cashierService ??= new CashierService(unitOfWork);
        }

        /// <summary>
        /// Get all cashiers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Cashier>> GetAll()
        {
            return await _cashierService.GetAll();
        }

        /// <summary>
        /// Get cashier using ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<Cashier> GetById([FromRoute] int id)
        {
            return await _cashierService.GetById(id);
        }

        /// <summary>
        /// Create cashiers
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Cashier> Post([FromBody] CashiersDTO cashierDTO)
        {
            Cashier cashier = _mapper.Map<Cashier>(cashierDTO);
            return await _cashierService.Add(cashier);
        }

        /// <summary>
        /// Update cashiers
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] CashiersDTO cashiersDTO)
        {
            Cashier cashier = _mapper.Map<Cashier>(cashiersDTO);
            cashier.CashierId = id;
            await _cashierService.Update(cashier);
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
            await _cashierService.Delete(id);
        }
    }
}

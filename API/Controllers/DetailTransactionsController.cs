using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingEcomindo.BLL;
using OnboardingEcomindo.BLL.DTO;
using OnboardingEcomindo.DAL.Models;
using OnboardingEcomindo.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnboardingEcomindo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailTransactionsController
    {
        private readonly IMapper _mapper;
        private readonly DetailTransactionService _detailTransactionService;

        public DetailTransactionsController(UnitOfWork unitOfWork)
        {
            MapperConfiguration config = new MapperConfiguration(m =>
            {
                m.CreateMap<DetailTransactionsDTO, DetailTransaction>();
                m.CreateMap<DetailTransaction, DetailTransactionsDTO>();
            });

            _mapper = config.CreateMapper();
            _detailTransactionService = new DetailTransactionService(unitOfWork);
        }


        /// <summary>
        /// Get all DetailTransaction
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<DetailTransaction>> GetAll()
        {
            return await _detailTransactionService.GetAll();
        }

        /// <summary>
        /// Get DetailTransaction Using ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<DetailTransaction> GetById([FromRoute] int id)
        {
            return await _detailTransactionService.GetById(id);
        }

        /// <summary>
        /// Create DetailTransaction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<DetailTransaction> Post([FromBody] DetailTransactionsDTO detailTransactionDTO)
        {
            DetailTransaction detailTransaction = _mapper.Map<DetailTransaction>(detailTransactionDTO);
            return await _detailTransactionService.Add(detailTransaction);
        }

        /// <summary>
        /// Update DetailTransaction
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transactionDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] DetailTransactionsDTO detailTransactionDTO)
        {
            DetailTransaction detailTransaction = _mapper.Map<DetailTransaction>(detailTransactionDTO);
            detailTransaction.DetailTransactionId = id;
            await _detailTransactionService.Update(detailTransaction);
        }
        /// <summary>
        /// Delete DetailTransaction using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _detailTransactionService.Delete(id);
        }
    }
}

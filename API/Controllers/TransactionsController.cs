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
    public class TransactionsController
    {
        private readonly TransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionsController(UnitOfWork unitOfWork)
        {
            MapperConfiguration config = new MapperConfiguration(m =>
            {
                m.CreateMap<TransactionsDTO, Transaction>();
                m.CreateMap<Transaction, TransactionsDTO>();
            });

            _mapper = config.CreateMapper();
            _transactionService = new TransactionService(unitOfWork);
        }


        /// <summary>
        /// Get all Transaction
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _transactionService.GetAll();
        }

        /// <summary>
        /// Get Transaction Using ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<Transaction> GetById([FromRoute] int id)
        {
            return await _transactionService.GetById(id);
        }

        /// <summary>
        /// Create Transaction
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Transaction> Post([FromBody] TransactionsDTO transactionDTO)
        {
            Transaction transaction = _mapper.Map<Transaction>(transactionDTO);
            return await _transactionService.Add(transaction);
        }

        /// <summary>
        /// Update Transaction
        /// </summary>
        /// <param name="id"></param>
        /// <param name="transactionDTO"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task Update([FromRoute] int id, [FromBody] TransactionsDTO transactionDTO)
        {
            Transaction transaction = _mapper.Map<Transaction>(transactionDTO);
            transaction.TransactionId = id;
            await _transactionService.Update(transaction);
        }
        /// <summary>
        /// Delete Transaction using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await _transactionService.Delete(id);
        }
    }
}

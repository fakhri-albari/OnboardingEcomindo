using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnboardingEcomindo.DTO;
using OnboardingEcomindo.Models;
using OnboardingEcomindo.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnboardingEcomindo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController
    {
        private UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            MapperConfiguration config = new MapperConfiguration(m =>
            {
                m.CreateMap<TransactionsDTO, Transaction>();
                m.CreateMap<Transaction, TransactionsDTO>();
            });

            _mapper = config.CreateMapper();
        }


        /// <summary>
        /// Get all Transaction
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<Transaction>> GetAll()
        {
            return await _unitOfWork.TransactionRepo.GetAll();
        }

        /// <summary>
        /// Get Transaction Using ID
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<Transaction> GetById([FromRoute] int id)
        {
            return await _unitOfWork.TransactionRepo.GetById(id);
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
            return await _unitOfWork.TransactionRepo.Add(transaction);
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
            await _unitOfWork.TransactionRepo.Update(transaction);
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
            await _unitOfWork.TransactionRepo.Delete(id);
        }
    }
}

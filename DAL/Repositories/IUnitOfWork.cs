﻿using Microsoft.EntityFrameworkCore.Storage;
using OnboardingEcomindo.DAL.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnboardingEcomindo.DAL.Repositories
{
    public interface IUnitOfWork
    {
        IGenericRepository<Item> ItemRepo { get; }
        IGenericRepository<Cashier> CashierRepo { get; }
        IGenericRepository<Transaction> TransactionRepo { get; }
        IGenericRepository<DetailTransaction> DetailTransactionRepo { get; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System;

namespace OnboardingEcomindo.Models
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int CashierId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        public ICollection<DetailTransaction> DetailTransactions { get; set; }
    }
}

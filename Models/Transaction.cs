using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.ComponentModel.DataAnnotations;

namespace OnboardingEcomindo.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public int TotalPrice { get; set; }
        public int TotalQuantity { get; set; }

        // Foreign Attributes

        public int CashierId { get; set; }
        public Cashier Cashier { get; set; }
    }
}

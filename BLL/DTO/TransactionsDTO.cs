using System;

namespace OnboardingEcomindo.BLL.DTO
{
    public class TransactionsDTO
    {
        public DateTime TransactionDate { get; set; }
        public int TotalPrice { get; set; }
        public int TotalQuantity { get; set; }

        // Foreign Attributes

        public int CashierId { get; set; }
    }
}

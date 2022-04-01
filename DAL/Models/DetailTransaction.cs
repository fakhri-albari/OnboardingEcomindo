using System.ComponentModel.DataAnnotations;

namespace OnboardingEcomindo.DAL.Models
{
    public class DetailTransaction
    {
        [Key]
        public int DetailTransactionId { get; set; }
        //public int TransactionId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }

        // Foreign Attribute
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }
    }
}

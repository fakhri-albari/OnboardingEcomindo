namespace OnboardingEcomindo.DTO
{
    public class DetailTransactionsDTO
    {
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int TotalPrice { get; set; }

        // Foreign Attribute
        public int ItemId { get; set; }

        public int TransactionId { get; set; }
    }
}

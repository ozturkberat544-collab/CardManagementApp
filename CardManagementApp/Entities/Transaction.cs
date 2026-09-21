namespace CardManagementApp.Entities
{
    public class Transaction : BaseEntity
    {
        public int CardId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        public Card Card { get; set; } = null!;
    }
}
namespace CardManagementApp.Entities
{
    public class Card : BaseEntity
    {
        public string CardNumber { get; set; } = string.Empty;
        public string CardHolderName { get; set; } = string.Empty;
        public decimal Limit { get; set; }
        public decimal Balance { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
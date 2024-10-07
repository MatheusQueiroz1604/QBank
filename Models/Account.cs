namespace QBank.Models
{
    public class Account
    {
        public int accountId { get; set; }
        public decimal balance { get; set; } = 0.0m;
        public string accountNumber { get; set; } = string.Empty;
        public string accountType { get; set; } = string.Empty;
        public DateTime openingDate { get; set; }
        public int clientId { get; set; }
    }
}
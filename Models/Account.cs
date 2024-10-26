namespace QBank.Models
{
    public class Account
    {
        public int accountId { get; set; }
        private decimal balance = 0.0m;
        public decimal Balance
        {
            get => balance;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative.");
                balance = value;
            }
        }
        public string accountNumber { get; set; } = string.Empty;
        public string accountType { get; set; } = string.Empty;
        public DateTime openingDate { get; set; } = DateTime.Now;
        public int clientId { get; set; }

        // Propriedades de Cartão vinculadas à conta
        public decimal creditLimit { get; set; } = 0.0m;
        public decimal currentBill { get; set; } = 0.0m;
        public decimal availableBalance { get; set; } = 0.0m;

        public Account() { }

        public Account(int accountId, string accountNumber, int clientId)
        {
            this.accountId = accountId;
            this.accountNumber = accountNumber;
            this.clientId = clientId;
            this.openingDate = DateTime.Now;
        }
    }
}
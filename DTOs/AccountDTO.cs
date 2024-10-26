namespace QBank.DTOs
{
    public class AccountDTO
    {
        public int accountId { get; set; }
        private decimal balance { get; set; } // Exposição do saldo pode ser sensível
        public string accountNumber { get; set; } = string.Empty;
        public string accountType { get; set; } = string.Empty;
        public DateTime openingDate { get; set; }
        public int clientId { get; set; }
        public decimal creditLimit { get; set; } = 0.0m;
        public decimal currentBill { get; set; } = 0.0m;
        public decimal availableBalance { get; set; } = 0.0m;

        public decimal Balance
        {
            get => balance;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative.");
                balance = value;
            }
        }

        public AccountDTO() { }

        public AccountDTO(int accountId, string accountNumber, int clientId)
        {
            this.accountId = accountId;
            this.accountNumber = accountNumber;
            this.clientId = clientId;
            this.openingDate = DateTime.Now;
        }

        public void UpdateBalance(decimal newBalance)
        {
            Balance = newBalance;
        }
    }
}
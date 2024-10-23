namespace QBank.Models 
{
    public class Transaction
    {
        public int transactionId { get; set; }
        public string transactionType { get; set; } = string.Empty;
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public int originAccountId { get; set; }
        public int? destinationAccountId { get; set; }

        // Propriedades específicas para cada tipo de transação
        public DebitCard? debitCardDetails { get; set; }
        public CreditCard? creditCardDetails { get; set; }
        public PIX? pixDetails { get; set; }
        public BankSlip? bankSlipDetails { get; set; }
        public Loan? loanDetails { get; set; }
    }
}
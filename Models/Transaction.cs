using QBank.Enums;

namespace QBank.Models 
{
    public class Transaction
    {
        public int transactionId { get; set; }
        public TransactionType transactionType { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public int originAccountId { get; set; }
        public int? destinationAccountId { get; set; }

        // Informações específicas para cada tipo de transação
        public string barcode { get; set; } = string.Empty; // Para boletos bancários
        public string pixKey { get; set; } = string.Empty;
        public string pixKeyType { get; set; } = string.Empty;
        public decimal? interestRate { get; set; }
        public int? numberParcels { get; set; }
        public DateTime? dueDate { get; set; } // Para boletos ou empréstimos
        public DateTime? approvalDate { get; set; } // Para cartões

        public Transaction() { }

        public Transaction(int transactionId, TransactionType transactionType, decimal amount, int originAccountId)
        {
            this.transactionId = transactionId;
            this.transactionType = transactionType;
            this.amount = amount;
            this.originAccountId = originAccountId;
            this.date = DateTime.Now; // Define a data de transação como o momento da criação
        }
    }
}
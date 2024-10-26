using QBank.Enums;

namespace QBank.DTOs 
{
    public class TransactionDTO
    {
        public int transactionId { get; set; }
        public TransactionType transactionType { get; set; }
        public decimal amount { get; set; }
        public DateTime date { get; set; }
        public int originAccountId { get; set; }
        public int? destinationAccountId { get; set; }
    
        public string barcode { get; set; } = string.Empty;
        public string pixKey { get; set; } = string.Empty;
        public string pixKeyType { get; set; } = string.Empty;
        public decimal? interestRate { get; set; }
        public int? numberParcels { get; set; }
        public DateTime? dueDate { get; set; }
        public DateTime? approvalDate { get; set; }

        public TransactionDTO() { }

        public TransactionDTO(int transactionId, TransactionType transactionType, decimal amount, int originAccountId)
        {
            this.transactionId = transactionId;
            this.transactionType = transactionType;
            this.amount = amount;
            this.originAccountId = originAccountId;
            this.date = DateTime.Now;
        }  
    }
}
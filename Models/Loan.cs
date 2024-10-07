namespace QBank.Models 
{
    public class Loan
    {
        public int loanId { get; set; }
        public int clientId { get; set; }
        public decimal amount { get; set; }
        public DateTime requestDate { get; set; }
        public DateTime deadline { get; set; }
        public decimal? interestRate { get; set; }
        public int? numberParcels { get; set; }
    } 
}
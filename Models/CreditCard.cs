namespace QBank.Models 
{
    public class CreditCard
    {
        public int creditCardId { get; set; }
        public int clientId { get; set; }
        public decimal currentBill { get; set; }
        public DateTime approvalDate { get; set; }
        public decimal limit { get; set; }
    }
}
namespace QBank.Models 
{
    public class DebitCard
    {
        public int cardId { get; set; }
        public int clientId { get; set; }
        public decimal availableBalance { get; set; }
        public DateTime approvalDate { get; set; }
    }
}
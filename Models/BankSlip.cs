namespace QBank.Models 
{
    public class BankSlip
    {
        public int bankSlipId { get; set; }
        public string barcode { get; set; } = string.Empty;
        public string status {get; set; } = string.Empty;
        public DateTime dueDate { get; set; }
    }
}
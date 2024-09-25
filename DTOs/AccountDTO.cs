namespace QBank.DTOs
{
    public class AccountDTO
    {
        public int id {get; set;}
        public string AccountNumber {get; set;} = string.Empty;
        public string AccountHolder {get; set;} = string.Empty;
        public decimal? Balance {get; set;}
    }
}
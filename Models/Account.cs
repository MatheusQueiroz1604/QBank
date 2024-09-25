namespace QBank.Models
{
    public class Account
    {
        public int id {get; set;}
        public string AccountNumber {get; set;} = string.Empty;
        public string AccountHolder {get; set;} = string.Empty;
        public decimal? Balance {get; set;}
    }
}
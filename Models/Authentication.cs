namespace QBank.Models 
{
    public class Authentication
    {
        public int authenticationId { get; set; }
        public int clientId { get; set; }
        public string token { get; set; } = string.Empty;
        public DateTime expirationDate { get; set; }
    }
}
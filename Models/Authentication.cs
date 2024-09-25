namespace QBank.Models {
    public class Authentication
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime DataExpiracao { get; set; }
    }
}
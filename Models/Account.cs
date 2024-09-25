namespace QBank.Models
{
    public class Account
    {
        public int id {get; set;}
        public decimal? Saldo {get; set;}
        public string NumeroConta { get; set; } = string.Empty;
        public string TipoConta { get; set; } = string.Empty;
        public DateTime DataAbertura { get; set; }
        public int ClienteId { get; set; }
    }
}
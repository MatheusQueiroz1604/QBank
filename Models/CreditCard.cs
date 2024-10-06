namespace QBank.Models {
    public class CreditCard
    {
        public int CartaoId { get; set; }
        public int ClienteId { get; set; }
        public decimal FaturaAtual { get; set; }
        public DateTime DataAprovacao { get; set; }
        public decimal Limite { get; set; }
    }
}
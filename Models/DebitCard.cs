namespace QBank.Models 
{
    public class DebitCard
    {
        public int CartaoId { get; set; }
        public int ClienteId { get; set; }
        public decimal SaldoDisponivel { get; set; }
        public DateTime DataAprovacao { get; set; }
    }
}
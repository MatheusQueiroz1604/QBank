namespace QBank.Models 
{
    public class Loan
    {
        public int EmprestimoId { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime Prazo { get; set; }
        public decimal? Juros { get; set; }
        public int NumeroParcelas { get; set; }
    }
}
namespace QBank.Models {
    public class Borrowing
    {
        public int EmprestimoId { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public DateTime Prazo { get; set; }
        public int? Juros { get; set; }
    }
}
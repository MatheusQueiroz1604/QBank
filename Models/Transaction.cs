namespace Qbank.Models {
    public class Transaction
    {
        public int TransacaoId { get; set; }
        public string TipoTransacao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int ContaOrigemId { get; set; }
        public int? ContaDestinoId { get; set; }
    }
}
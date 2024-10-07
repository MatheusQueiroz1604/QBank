namespace QBank.Models 
{
    public class Boleto 
    {
        public int BoletoId { get; set; }
        public string CodigoBarras { get; set; } = string.Empty;
        public string Status { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
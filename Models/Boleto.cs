namespace QBank.Models 
{
    public class Boleto 
    {
        public int BoletoId { get; set; }
        public string CodigoBarras { get; set; } = string.Empty;
        public DateTime DataVencimento { get; set; }
    }
}
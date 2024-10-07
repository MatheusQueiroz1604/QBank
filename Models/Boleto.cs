namespace QBank.Models 
{
    public class Boleto 
    {
        public string CodigoBarras { get; set; } = string.Empty;
        public DateTime DataVencimento { get; set; }
    }
}
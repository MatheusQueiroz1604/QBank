using QBank.Models;

namespace Qbank.Models 
{
    public class Transaction
    {
        public int TransacaoId { get; set; }
        public string TipoTransacao { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int ContaOrigemId { get; set; }
        public int? ContaDestinoId { get; set; }

        //Propriedades específicas para cada tipo de transação
        public DebitCard? DebitCardDetails { get; set; }
        public CreditCard? CreditCardDetails { get; set; }
        public PIX? PixDetails { get; set; }
        public Boleto? BoletoDetails { get; set; }
        public Loan? LoanDetails { get; set; }
    }
}
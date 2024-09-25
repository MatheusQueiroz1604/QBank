namespace Qbank.Models {
    public class User
    {
            public int Id { get; set; }
            public string Nome {get; set;} = string.Empty;
            public string CPF {get; set;} = string.Empty;
            public string Email {get; set;} = string.Empty;
            public string Senha {get; set;} = string.Empty;
            public DateTime DataNascimento { get; set; }
            public string Telefone { get; set; } = string.Empty;
    }
}
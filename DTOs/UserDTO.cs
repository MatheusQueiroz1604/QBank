namespace QBank.DTOs 
{    
    public class UserDTO
    {
        public int userId { get; set; }
        public string name { get; set; } = string.Empty;
        public string cpf { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
    
        public UserDTO() { }

        public UserDTO(int userId, string name, string cpf, string email)
        {
            this.userId = userId;
            this.name = name;
            this.cpf = cpf;
            this.email = email;
        }
    }
}
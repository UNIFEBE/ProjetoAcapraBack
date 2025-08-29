namespace Acapra.Domain.DTOs
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public LoginRequest() { }

        public LoginRequest(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }
}

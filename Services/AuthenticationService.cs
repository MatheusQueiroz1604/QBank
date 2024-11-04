using QBank.Models;
using QBank.Data;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace QBank.Services {
    public class AuthenticationService
    {
        private readonly AppDbContext _dbContext;
        private static Dictionary<int, string> activeTokens = new Dictionary<int, string>();

        public AuthenticationService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string? GenerateToken(int clientId)
        {
            string token = Guid.NewGuid().ToString();
            activeTokens[clientId] = token; 

            PrintActiveTokens();
            return token;
        }
        public void PrintActiveTokens()
        {
            Console.WriteLine("Active Tokens:");
            foreach (var kvp in activeTokens)
            {
                Console.WriteLine($"Client ID: {kvp.Key}, Token: {kvp.Value}");
            }
        }

        public Task<int> GetClientIdFromTokenAsync(string token)
        {
            return Task.Run(() =>
            {
                PrintActiveTokens();
                var clientId = activeTokens.FirstOrDefault(x => x.Value == token).Key;
        
                if (clientId == 0)
                {
                    throw new UnauthorizedAccessException("Client ID not found in claims.");
                }

                return clientId;
            });
        }

        public bool ValidateToken(int clientId, string token)
        {
            return activeTokens.TryGetValue(clientId, out var activeToken) && activeToken == token;
        }
        
        public void ExpireToken(int clientId)
        {
            if (activeTokens.ContainsKey(clientId))
            {
                activeTokens.Remove(clientId);
                Console.WriteLine($"Token expired for Client ID: {clientId}");
            }
        }
        public User? Authenticate(string email, string password)
        {
            var user = _dbContext.Users.AsNoTracking().FirstOrDefault(u => u.email == email);
            if (user == null || password != user.password)
            {
                return null; // Autenticação falhou
            }
            return user;
        }
    }
}
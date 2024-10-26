namespace QBank.Services {
    public class AuthenticationService
    {
        private Dictionary<int, string> activeTokens = new Dictionary<int, string>();

        public string GenerateToken(int clientId)
        {
            string token = Guid.NewGuid().ToString();
            activeTokens[clientId] = token;
            return token;
        }

        public bool ValidateToken(int clientId, string token)
        {
            return activeTokens.ContainsKey(clientId) && activeTokens[clientId] == token;
        }

        public void ExpireToken(int clientId)
        {
            if (activeTokens.ContainsKey(clientId))
            {
                activeTokens.Remove(clientId);
            }
        }
    }
}
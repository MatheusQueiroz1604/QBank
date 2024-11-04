using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using QBank.Services;
using System.Security.Claims;

namespace QBank.Filters
{
    public class TokenAuthorizeAttribute : TypeFilterAttribute
    {
        public TokenAuthorizeAttribute() : base(typeof(TokenAuthorizeFilter))
        {
        }
    }

    public class TokenAuthorizeFilter : IAsyncAuthorizationFilter
    {
        private readonly AuthenticationService _authenticationService;

        public TokenAuthorizeFilter(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            Console.WriteLine($"Received token: {token}");

            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (string.IsNullOrWhiteSpace(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            try
            {
                // Aqui você pode validar o token e talvez expirar um token se necessário
                var clientId = _authenticationService.GetClientIdFromTokenAsync(token).Result;

                if (!_authenticationService.ValidateToken(clientId, token))
                {
                    context.Result = new UnauthorizedResult();
                }
            }
            catch (UnauthorizedAccessException)
            {
                context.Result = new UnauthorizedResult();
            }
        }  

        private int GetClientIdFromRequest(AuthorizationFilterContext context)
        {
            var claimsPrincipal = context.HttpContext.User;

            if (claimsPrincipal != null && claimsPrincipal.Identity != null && claimsPrincipal.Identity.IsAuthenticated)
            {
                var clientIdClaim = claimsPrincipal.FindFirst("clientId");

                if (clientIdClaim != null && int.TryParse(clientIdClaim.Value, out int clientId))
                {
                    return clientId;
                }
            }

            throw new UnauthorizedAccessException("Client ID not found in claims.");
        }
    }
}
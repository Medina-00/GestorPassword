using GestorPassword.Core.Application.Dtos.Account.Response;
using Microsoft.AspNetCore.Http;
using GestorPassword.Core.Application.Helpers;


namespace GestorPassword.Middlewares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            AuthenticationResponse authentication = httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");

            if (authentication == null)
            {
                return false;
            }
            return true;
        }

    }
}

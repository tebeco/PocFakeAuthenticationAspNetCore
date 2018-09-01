using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApiMultiIndexEls.Services
{
    public class UserService
    {
        private readonly ILoggerFactory _loggerFactory;
        private ILogger _loggerForLogin;

        public UserService(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _loggerForLogin = _loggerFactory.CreateLogger("LoginCategory");
        }

        public async Task<bool> LoginAsync(HttpContext httpContext, string userName)
        {
            if(userName == "deny")
            {
                _loggerForLogin.LogWarning("An failed login attempt happened for user {UserName}", userName);
                return false;
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, userName));

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            _loggerForLogin.LogInformation("An successfull login happened for user {UserName}", userName);
            return true;
        }

        public async Task LogoutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}

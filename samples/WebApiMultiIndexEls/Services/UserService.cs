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
        public UserService(ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
        }

        public ILoggerFactory LoggerFactory { get; }

        public async Task<bool> LoginAsync(HttpContext httpContext, string userName)
        {
            if(userName == "deny")
            {
                return false;
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, userName));

            await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            return true;
        }

        public async Task LogoutAsync(HttpContext httpContext)
        {
            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}

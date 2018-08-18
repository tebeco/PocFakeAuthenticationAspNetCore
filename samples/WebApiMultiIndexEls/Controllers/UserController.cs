using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiMultiIndexEls.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult<User> Current()
        {
            return new User { UserName = HttpContext.User.Identity.Name };
        }

        [HttpGet]
        public async Task Login([FromQuery]string returnUrl = null)
        {
            var user = new User() { UserName = "FakeUser" };
            await LoginAsync(user, returnUrl);
        }

        [HttpPost]
        public async Task Login([FromBody]User user, [FromQuery] string returnUrl = null)
        {
            await LoginAsync(user, returnUrl);
            Redirect(returnUrl ?? "/");
        }

        private async Task LoginAsync(User user, string returnUrl)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }

        [HttpGet]
        public async Task<ActionResult<string>> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return "You've been logged out";
        }
    }
}
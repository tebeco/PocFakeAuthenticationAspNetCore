using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiMultiIndexEls.Services;

namespace WebApiMultiIndexEls.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task Login([FromBody]string userName)
        {
            await _userService.LoginAsync(HttpContext, userName);
        }

        [HttpGet]
        public async Task Logout()
        {
            await _userService.LogoutAsync(HttpContext);
        }
    }
}
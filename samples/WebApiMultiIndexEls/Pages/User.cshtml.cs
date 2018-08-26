using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiMultiIndexEls.Services;

namespace WebApiMultiIndexEls
{
    [Authorize]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class UserModel : PageModel
    {
        private readonly UserService _userService;

        public string UserName { get; set; }

        public UserModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
            UserName = User.Identity.Name;
        }

        public async Task<IActionResult> OnPost()
        {
            await _userService.LogoutAsync(HttpContext);
            return Redirect("User");
        }
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApiMultiIndexEls.Services;

namespace WebApiMultiIndexEls.Pages
{
    public class LoginModel : PageModel
    {
        private readonly UserService _userService;

        public LoginModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string UserName { get; set; }

        public async Task<IActionResult> OnPost()
        {
            await _userService.LoginAsync(HttpContext, UserName);
            return RedirectToPage("User");
        }
    }
}
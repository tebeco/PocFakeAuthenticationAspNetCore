using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApiMultiIndexEls.Pages
{
    public class UnauthenticatedModel : PageModel
    {
        public IActionResult OnPost()
        {
            return RedirectToPage("Login");
        }
    }
}
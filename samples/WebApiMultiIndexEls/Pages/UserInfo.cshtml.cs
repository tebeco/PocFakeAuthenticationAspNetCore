using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApiMultiIndexEls
{
    [Authorize]
    public class UserInfoModel : PageModel
    {
        public string UserName { get; set; }

        public void OnGet()
        {
            UserName = User.Identity.Name;
        }
    }
}
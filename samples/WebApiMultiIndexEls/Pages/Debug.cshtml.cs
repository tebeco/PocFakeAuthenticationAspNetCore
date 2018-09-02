using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogAsCode;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace WebApiMultiIndexEls.Pages
{
    public class DebugModel : PageModel
    {
        private readonly IOptions<ElasticSearchOptions> _elsOptions;

        public DebugModel(IOptions<ElasticSearchOptions> elsOptions)
        {
            _elsOptions = elsOptions;
        }

        public ElasticSearchOptions ElsOptions { get; set; }

        public void OnGet()
        {
            ElsOptions = _elsOptions.Value;
        }
    }
}
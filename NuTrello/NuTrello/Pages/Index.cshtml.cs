using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace NuTrello.Pages
{
    public class IndexModel : PageModel
    {

        // Här ska listan på bräden genereras om bräden finns
        // skall ta in alt. generera ett id som vi sedan appendar till boards ex. boards/{id}


        //random variable to vizualise an existing board
        public string boards = "ett bräde";
        private readonly ILogger<IndexModel> _logger;


        public void inserList()
        {
            


        }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }


    }
}

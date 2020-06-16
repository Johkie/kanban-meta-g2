using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NuTrello.Pages
{

    // Här vill vi ha all information om brädet(id) som vi valt att visa
    //
    
    public class BoardsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int BoardId { get; set; }

        public List<string> lists= new List<string>(){"todo","doing","done"};
        public List<string> tasks= new List<string>(){"todo","todo","doing","todo","done","todo"};


        public void OnGet()
        {
        }

        public string insertTask()
        {
            return "Task Created";
        }
    }
}

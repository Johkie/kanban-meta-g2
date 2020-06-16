using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuTrello.Data.Context;


namespace NuTrello.Pages
{

    // Här vill vi ha all information om brädet(id) som vi valt att visa
    //
    
    public class BoardsModel : PageModel
    {
        
        // public Task OnGet()
        // {
        //     //return _context.Lists.ToList();
        // }

       

        public string insertList()
        {
            return "hej";
        }

        // public string insertTask(DbTaskModel task)
        // {
        //     _context.Tasks.Add(task);
        // }
    }
}

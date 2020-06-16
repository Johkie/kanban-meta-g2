using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuTrello.Data.Context;
using NuTrello.Modelss.cs;


namespace NuTrello.Pages.forms
{
    public class AddNewTask : PageModel
    {
        [BindProperty]
        public CreateNewTask NewTaskCreated { get; set; }

        public void OnGet()
        {

        }

         public IActionResult onPost()
        {
          if (ModelState.IsValid == false)
          {
              return Page();
          }

          return RedirectToPage("./Index");
        
        }

    }
}
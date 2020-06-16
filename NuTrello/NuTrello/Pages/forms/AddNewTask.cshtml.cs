using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NuTrello.Data.Context;
using NuTrello.Modelss.cs;
using NuTrello.Data.Repository;


namespace NuTrello.Pages.forms
{
    public class AddNewTask : PageModel
    {


      public AddNewTask(TaskRepository _taskRepository)
      {
          this.taskRepository = _taskRepository;
      }
      
      private readonly TaskRepository taskRepository;


        [BindProperty]
        public CreateNewTask NewTaskCreated { get; set; }


        

        public void OnGet()
        {

        }

         public IActionResult onPost()
        {
          if (ModelState.IsValid == false)
          {
              // taskRepository.InitializeNewTask(DbListModel listToAddTask, string title, string desc)
              return Page();
          }

          return RedirectToPage("./Index");
        
        }

    }
}
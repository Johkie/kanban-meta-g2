using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using NuTrello.Data.Repository;
using NuTrello.Models;
using NuTrello.Modelss.cs;
using NuTrello.Data.Repository;


namespace NuTrello.Pages
{

    // Här vill vi ha all information om brädet(id) som vi valt att visa
    public class BoardsModel : PageModel
    {
        private readonly IBoardRepository _boardRepository;

        // ID of the board fetched from URL
        [BindProperty(SupportsGet = true)]
        public int BoardId { get; set; }

        // Current board
        public DbBoardModel board { get; set; }

        [BindProperty]
        public CreateNewTask NewTaskCreated { get; set; }

        [BindProperty]
        public CreateNewList NewListCreated { get; set; }

        public BoardsModel(TaskRepository _taskRepository)
        {
            this.taskRepository = _taskRepository;
        }

        private readonly TaskRepository taskRepository;


        public BoardsModel(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public IActionResult onPost()
        {
            if (ModelState.IsValid == false)
            {
                //behöver specefika listId för att kunna skicka in informationen till databsen
                var TaskTitle = Request.Form["title"];
                var TaskDescription = Request.Form["description"];

                // taskRepository.InitializeNewTask( ,TaskTitle, TaskDescription);
                return Page();
            }

            return RedirectToPage("./Index");

        }

        public void OnGet()

        {

            // GetLists = this.taskRepository.GetTask();
            //return _context.Lists.ToList();
        }



        public string insertList()

        {
            board = _boardRepository.GetBoard(BoardId);
        }


        // public string insertTask(DbTaskModel task)
        // {
        //     _context.Tasks.Add(task);
        // }

    }
}

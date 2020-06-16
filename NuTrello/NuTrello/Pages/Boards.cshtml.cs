using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using NuTrello.Data.Repository;
using NuTrello.Models;
using NuTrello.Modelss.cs;


namespace NuTrello.Pages
{

    // Här vill vi ha all information om brädet(id) som vi valt att visa
    //
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


        public BoardsModel(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }


        public IActionResult onPost()
        {
            if (ModelState.IsValid == false)
            {
                // taskRepository.InitializeNewTask(DbListModel listToAddTask, string title, string desc)
                //   lists.Add(NewTaskCreated.Title);

                return Page();
            }

            return RedirectToPage("./Index");

        }

        public void OnGet()
        {
            board = _boardRepository.GetBoard(BoardId);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using NuTrello.Models;
using NuTrello.Modelss.cs;
using NuTrello.Data.Repository;

namespace NuTrello.Pages
{
    public class IndexModel : PageModel
    {
        // Här ska listan på bräden genereras om bräden finns
        // skall ta in alt. generera ett id som vi sedan appendar till boards ex. boards/{id}

        private readonly IBoardRepository _boardRepo;
        public List<DbBoardModel> boards;

        [BindProperty]
        public CreateNewBoard newBoard { get; set; }

        public IndexModel(IBoardRepository boardRepository)
        {
            _boardRepo = boardRepository;
        }

        public void OnGet()
        {
            // Get all boards from db
            boards = _boardRepo.GetBoards();
        }   

        public IActionResult OnPostNewBoard()
        {
            // If title is empty, redirect back to homepage.
            if (string.IsNullOrEmpty(newBoard.Title)) 
            {
                return RedirectToPage("/Index");
            }
            // Init board to db and get new id
            int newBoardId = (int)_boardRepo.InitializeNewBoard(newBoard.Title, newBoard.Description);

            // Redirect to board page with the new id
            return RedirectToPage("/Boards", new {boardId = newBoardId});
        }
    }
}

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
        private readonly IListRepository _listRepository;
        private readonly ITaskRepository _taskRepository;

        // ID of the board fetched from URL
        [BindProperty(SupportsGet = true)]
        public int BoardId { get; set; }

        // Current board
        public DbBoardModel board { get; set; } = new DbBoardModel();

        [BindProperty]
        public CreateNewTask NewTaskCreated { get; set; }

        [BindProperty]
        public CreateNewList NewListCreated { get; set; }

        public BoardsModel(IBoardRepository boardRepository, IListRepository listRepository, ITaskRepository taskRepository)
        {
            _boardRepository = boardRepository;
            _listRepository = listRepository;
            _taskRepository = taskRepository;
        }

        public IActionResult OnPostCreateTask(int listId)
        {
            // If title field has been filled, post new task
            if(!string.IsNullOrEmpty(NewTaskCreated.Title))
            {
                // Get current board
                board = _boardRepository.GetBoard(BoardId);

                // Find matching list and post the new task on it.
                DbListModel list = board.Lists.First(l => l.Id == listId);
                _taskRepository.InitializeNewTask(list, NewTaskCreated.Title, NewTaskCreated.Description);
            }

            // Redirect to board page
            return RedirectToPage("/Boards", new {boardId = BoardId});
        }

        public IActionResult OnPostCreateList()
        {
            // If field is filled, post new list
            if(!string.IsNullOrEmpty(NewListCreated.ListName))
            {
                // Get current board
                board = _boardRepository.GetBoard(BoardId);

                // Create new list on board
                _listRepository.InitializeNewList(board, NewListCreated.ListName);
            }

            // Redirect to board page
            return RedirectToPage("/Boards", new {boardId = BoardId});
        }

        public void OnGet()
        {
            board = _boardRepository.GetBoard(BoardId);
        }
    }
}

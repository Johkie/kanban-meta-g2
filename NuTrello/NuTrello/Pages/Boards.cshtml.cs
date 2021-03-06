﻿using System;
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
        public CreateNewTask NewTask { get; set; }

        [BindProperty]
        public CreateNewList NewList { get; set; }

        [BindProperty]
        public DeleteList DeleteList { get; set; }

        [BindProperty]
        public MoveTaskToList MoveTask { get; set; }


        public BoardsModel(IBoardRepository boardRepository, IListRepository listRepository, ITaskRepository taskRepository)
        {
            _boardRepository = boardRepository;
            _listRepository = listRepository;
            _taskRepository = taskRepository;
        }

        public IActionResult OnPostCreateTask(int listId)
        {
            // If title field has been filled, post new task
            if (!string.IsNullOrEmpty(NewTask.Title))
            {
                // Get current board
                board = _boardRepository.GetBoard(BoardId);

                // Find matching list and post the new task on it.
                DbListModel list = board.Lists.First(l => l.Id == listId);
                _taskRepository.InitializeNewTask(list, NewTask.Title, NewTask.Description);
            }

            // Redirect to board page
            return RedirectToPage("/Boards", new { boardId = BoardId });
        }

        public IActionResult OnPostDeleteList()
        {
            // Remove list
            if (DeleteList.ListId != 0)
            {
                _listRepository.DeleteList(DeleteList.ListId);
            }

            // Redirect to board page
            return RedirectToPage("/Boards", new { boardId = BoardId });
        }

        public IActionResult OnPostDeleteTask(int taskId)
        {
            // Remove task from db
            _taskRepository.DeleteTask(taskId);

            // Redirect to board page
            return RedirectToPage("/Boards", new { boardId = BoardId });
        }

        public IActionResult OnPostCreateList()
        {
            // If field is filled, post new list
            if (!string.IsNullOrEmpty(NewList.Title))
            {
                // Get current board
                board = _boardRepository.GetBoard(BoardId);

                // Create new list on board
                _listRepository.InitializeNewList(board, NewList.Title);
            }

            // Redirect to board page
            return RedirectToPage("/Boards", new { boardId = BoardId });
        }

        public IActionResult OnPostMoveTaskToList()
        {
            if (MoveTask.TaskId > 0 && MoveTask.ListId > 0)
            {
                // Get list to place the task
                var newList = _listRepository.GetList(MoveTask.ListId);

                // Move task to the new list
                _taskRepository.MoveTaskToList(MoveTask.TaskId, newList);
            }

            // Redirect back to boardpage
            return RedirectToPage("/Boards", new { boardId = BoardId });
        }

        public void OnGet()
        {
            // Get board from passed url boardid
            board = _boardRepository.GetBoard(BoardId);
        }
    }
}

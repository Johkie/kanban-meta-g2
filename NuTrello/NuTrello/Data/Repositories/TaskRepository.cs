using System;
using NuTrello.Data.Context;
using NuTrello.Models;
using System.Linq;

namespace NuTrello.Data.Repository
{
    public interface ITaskRepository
    {
        public int? InitializeNewTask(int listId, string title, string desc);
        public bool DeleteTask(int boardId);
        public bool ModifyTaskInfo(int boardId, string param, string newValue);
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly NuTrelloContext _context;
        public TaskRepository(NuTrelloContext context)
        {
            _context = context;
        }
        
        /// <summary>Initialize a new task for specified list id.
        /// Returns the id of the new task if succeded.
        /// Returns null if failed.</summary>
         /// <param name="listId">The id of the list to add a task.</param>
         /// <param name="title">The title of the task.</param>
         /// <param name="desc">The description of the task.</param>
        public int? InitializeNewTask(int listId, string title, string desc)
        {
            try
            {
                // var task = new TaskModel { BoardListsModelId  Title = "MyBoard", Description = "Is a board" };
                // _context.Boards.Add(board);
                // _context.SaveChanges();
                // return board.Id;
                return null;
            }
            catch
            {
                // return null;
            }
            return null;
        }

        /// <summary>Method to delete a task based of id.
        /// Returns true if succeded.</summary>
        /// <param name="taskId">The id of the task.</param>
        public bool DeleteTask(int taskId)
        {
            try
            {
                // var board = _context.Boards.First(b => b.Id == boardId);
                // _context.Boards.Remove(board);
                // _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Method to modify a boards information based of id.
        /// Returns true if succeded.</summary>
        /// <param name="boardId">The id of the board.</param>
        /// <param name="param">The board parameter to change.</param>
        /// <param name="newValue">The new value to set</param>
        public bool ModifyTaskInfo(int boardId, string param, string newValue)
        {
            throw new NotImplementedException();
        }
    }
}
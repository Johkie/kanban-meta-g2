using System;
using System.Collections.Generic;
using System.Linq;
using NuTrello.Data.Context;
using NuTrello.Models;

namespace NuTrello.Data.Repository
{
    public interface IBoardRepository
    {
        public int? InitializeNewBoard(string title, string description);
        public List<DbBoardModel> GetBoards();
        public DbBoardModel GetBoard(int boardId);
        public bool DeleteBoard(int boardId);
        public bool ModifyBoardInfo(int boardId, string param, string newValue);
    }
    public class BoardRepository : IBoardRepository
    {
        private readonly NuTrelloContext _context;

        public BoardRepository(NuTrelloContext context)
        {
            _context = context;
        }

        /// <summary>Initialize a new board.
        /// Returns the id of the new board if succeded.
        /// Returns null if failed.</summary>
        public int? InitializeNewBoard(string title, string description)
        {
            try
            {
                // Create new board model
                var board = new DbBoardModel 
                { 
                    Title = title, 
                    Description = description 
                
                };

                // Add board to db and save changes
                _context.Boards.Add(board);
                _context.SaveChanges();

                // Return id of the new board
                return board.Id;
            }
            catch
            {
                // Return null if something went wrong
                return null;
            }
        }

        /// <summary>Method to delete a board based of id.
        /// Returns true if succeded.</summary>
        /// <param name="boardId">The id of the board.</param>
        public bool DeleteBoard(int boardId)
        {
            try
            {
                // Get board from db based of id
                var board = _context.Boards.FirstOrDefault(b => b.Id == boardId);

                // Remove board from db and save changes
                _context.Boards.Remove(board);
                _context.SaveChanges();

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
        public bool ModifyBoardInfo(int boardId, string param, string newValue)
        {
            throw new NotImplementedException();
        }


        /// <summary>Method to get all boards from the database.
        /// Returns a list of all boards.</summary>
        public List<DbBoardModel> GetBoards()
        {
            try
            {
                List<DbBoardModel> boards = _context.Boards.ToList();
                return boards;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>Method to get a specific board from the database.
        /// Returns the board if found.</summary>
        /// <param name="boardId">The id of the board.</param>
        public DbBoardModel GetBoard(int boardId)
        {
            try
            {
                DbBoardModel board = _context.Boards.FirstOrDefault(b => b.Id == boardId);
                return board;
            }
            catch
            {
                return null;
            }
        }
    }
}
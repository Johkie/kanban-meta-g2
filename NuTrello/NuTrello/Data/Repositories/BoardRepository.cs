using System;
using NuTrello.Data.Context;
using NuTrello.Models;
using System.Linq;

namespace NuTrello.Data.Repository
{
    public interface IBoardRepository
    {
        public int? InitializeNewBoard();
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
        public int? InitializeNewBoard()
        {
            try
            {
                var board = new BoardModel { Title = "MyBoard", Description = "Is a board" };
                _context.Boards.Add(board);
                _context.SaveChanges();
                return board.Id;
            }
            catch
            {
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
                var board = _context.Boards.First(b => b.Id == boardId);
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
    }
}
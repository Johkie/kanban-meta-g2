using System;
using NuTrello.Data.Context;

namespace NuTrello.Data.Repository 
{
    public interface IBoardRepository
    {
        public int InitializeNewBoard();
        public bool DeleteBoard(int boardId);
        public bool ModifyBoardInfo(int boardId, string param, string newValue);
    }
    public class BoardRepository : IBoardRepository
    {
        /// <summary>Initialize a new board.
        /// Returns the id of the new board if succeded.
        /// Returns null if failed.</summary>
        public int InitializeNewBoard()
        {
            throw new NotImplementedException();
        }

        /// <summary>Method to delete a board based of id.
        /// Returns true if succeded.</summary>
        /// <param name="boardId">The id of the board.</param>
        public bool DeleteBoard(int boardId)
        {
            throw new NotImplementedException();
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using NuTrello.Data.Context;
using NuTrello.Models;

namespace NuTrello.Data.Repository
{
    public interface IListRepository
    {
        public int? InitializeNewList(DbBoardModel boardModel, string title);
        public List<DbListModel> GetLists();
        public DbListModel GetList(int listId);
        public bool DeleteList(int listId);
        public bool ModifyListInfo(int listId, string newTitle);
    }
    public class ListRepository : IListRepository
    {
        private readonly NuTrelloContext _context;

        public ListRepository(NuTrelloContext context)
        {
            _context = context;
        }

        /// <summary>Initialize a new list.
        /// Returns true of succeded</summary>
        public int? InitializeNewList(DbBoardModel boardModel, string title)
        {
            try 
            {
                // Create new list model
                var list = new DbListModel
                {
                    Title = title,
                    DbBoardsModel = boardModel
                };

                // Insert list to db and save changes (list object gets updated with id and connections)
                _context.Lists.Add(list);
                _context.SaveChanges();

                // Return id of the new list
                return list.Id;
            }
            catch
            {   
                // Returns null if something went wrong
                return null;
            }
        }

        /// <summary>Method to delete a list based of id.
        /// Returns true if succeded.</summary>
        /// <param name="listId">The id of the list.</param>
        public bool DeleteList(int listId)
        {
            try
            {
                // Get list from db based of id
                var list = _context.Lists.FirstOrDefault(l => l.Id == listId);
                
                // Remove list from db and save changes
                _context.Lists.Remove(list);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Method to modify a list title based of id.
        /// Returns true if succeded.</summary>
        /// <param name="listId">The id of the list.</param>
        /// <param name="newTitle">The new title to set</param>
        public bool ModifyListInfo(int listId, string newTitle)
        {
            throw new NotImplementedException();
        }

        /// <summary>Method to get all lists from the database.
        /// Returns a list of all lists.</summary>
        public List<DbListModel> GetLists()
        {
            try
            {
                var lists = _context.Lists
                    .Include(t => t.Tasks)
                    .ToList();
                return lists;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>Method to get a specific list from the database.
        /// Returns the list if found.</summary>
        /// <param name="listId">The id of the List.</param>
        public DbListModel GetList(int listId)
        {
            try
            {
                var list = _context.Lists
                    .Include(t => t.Tasks)
                    .FirstOrDefault(l => l.Id == listId);
                return list;
            }
            catch 
            {
                return null;
            }
        }
    }
}
using System;
using NuTrello.Data.Context;
using NuTrello.Models;
using System.Linq;

namespace NuTrello.Data.Repository
{
    public interface ITaskRepository
    {
        int? InitializeNewTask(DbListModel listToAddTask, string title, string desc);
        bool DeleteTask(int taskId);
        DbTaskModel GetTask(int taskId);
        bool MoveTaskToList(int taskId, DbListModel newList);
        bool ModifyTaskInfo(int taskId, DbTaskModel modifiedTask);
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
        public int? InitializeNewTask(DbListModel listToAddTask, string title, string desc)
        {
            try
            {
                DbTaskModel task = new DbTaskModel 
                { 
                    Title = title, 
                    Description = desc,
                    DbListModel = listToAddTask,
                    TaskOrder = listToAddTask.Tasks.Count() 
                };

                _context.Tasks.Add(task);
                _context.SaveChanges();
                return task.Id;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>Method to delete a task based of id.
        /// Returns true if succeded.</summary>
        /// <param name="taskId">The id of the task.</param>
        public bool DeleteTask(int taskId)
        {
            try
            {
                // Get task from db based of id
                var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);

                // Remove task from db and save changes
                _context.Tasks.Remove(task);
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
        public bool ModifyTaskInfo(int taskId, DbTaskModel modifiedTask)
        {
            try
            {
                // Get task from db based of id
                var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);

                // Update task and save changes
                task = modifiedTask;
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Method to move task to another list.
        /// Returns true if succeded.</summary>
        /// <param name="taskId">The task to change lists</param>
        /// <param name="newList">The list to move the task into</param>
        public bool MoveTaskToList(int taskId, DbListModel newList)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            task.DbListModel = newList;
            task.TaskOrder = newList.Tasks.Count();

            _context.SaveChanges();
            return true;
        }

        public DbTaskModel GetTask(int taskId)
        {
            var task = _context.Tasks.First(t => t.Id == taskId);
            return task;
        }
    }
}
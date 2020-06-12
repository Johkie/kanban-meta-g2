using Microsoft.EntityFrameworkCore;
using NuTrello.Models;

namespace NuTrello.Context
{
    public class NuTrelloContext : DbContext
    {
        public DbSet<BoardModel> Boards { get; set; }
        public DbSet<ListModel> BoardLists { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }

        public NuTrelloContext(DbContextOptions<NuTrelloContext> options) : base(options)
        {
            
        }
    }
}
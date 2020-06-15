using Microsoft.EntityFrameworkCore;
using NuTrello.Models;

namespace NuTrello.Data.Context
{
    public class NuTrelloContext : DbContext
    {
        public DbSet<DbBoardModel> Boards { get; set; }
        public DbSet<DbListModel> Lists { get; set; }
        public DbSet<DbTaskModel> Tasks { get; set; }

        public NuTrelloContext(DbContextOptions<NuTrelloContext> options) : base(options)
        {
            
        }
    }
}
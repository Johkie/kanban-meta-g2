using System;
using System.Collections.Generic;

namespace NuTrello.Models
{
    public class DbListModel
    {
        public int Id { get; set; }
        public int DbBoardsModelId { get; set; }
        public DbBoardModel DbBoardsModel { get; set; }
        public ICollection<DbTaskModel> Tasks { get; set; } = new List<DbTaskModel>();
        public string Description { get; set; }
    }
}
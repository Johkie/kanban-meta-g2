using System;
using System.Collections.Generic;

namespace NuTrello.Models
{
    public class DbBoardModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<DbListModel> Lists { get; set; } = new List<DbListModel>();
    }
}
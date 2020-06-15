using System;
using System.Collections.Generic;

namespace NuTrello.Models
{
    public class DbTaskModel
    {
        public int Id { get; set; }
        public int DbListsModelId { get; set; }
        public DbListModel DbListsModel { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskOrder { get; set; }
    }
}
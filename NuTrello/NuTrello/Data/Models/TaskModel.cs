using System;
using System.Collections.Generic;

namespace NuTrello.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int BoardListsModelId { get; set; }
        public ListModel BoardListsModel { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TaskOrder { get; set; }
    }
}
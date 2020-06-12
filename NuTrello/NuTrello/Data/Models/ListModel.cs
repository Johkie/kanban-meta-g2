using System;
using System.Collections.Generic;

namespace NuTrello.Models
{
    public class ListModel
    {
        public int Id { get; set; }
        public int BoardsModelId { get; set; }
        public BoardModel BoardsModel { get; set; }
        public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
        public string Description { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace NuTrello.Models
{
    public class BoardModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<ListModel> BoardLists { get; set; } = new List<ListModel>();
    }
}
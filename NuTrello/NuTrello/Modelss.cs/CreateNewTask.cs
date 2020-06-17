using System.ComponentModel.DataAnnotations;

namespace NuTrello.Modelss.cs
{
    public class CreateNewTask
    {
        [Required(ErrorMessage="Title is required")]
        public string Title { get; set; }
        
        public string Description { get; set; }
    }
}
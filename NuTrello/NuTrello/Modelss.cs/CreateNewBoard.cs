using System.ComponentModel.DataAnnotations;

namespace NuTrello.Modelss.cs
{
    public class CreateNewBoard 
    {
        [Required]
        public string Title { get; set; }   
        [Required]
        public string Description { get; set; }
    }
}
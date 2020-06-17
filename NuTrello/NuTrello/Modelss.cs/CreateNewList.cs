using System.ComponentModel.DataAnnotations;

namespace NuTrello.Modelss.cs
{
    public class CreateNewList
    {
        [Required(ErrorMessage="Title is required")]
        public string Title {get;set;}
    }
}
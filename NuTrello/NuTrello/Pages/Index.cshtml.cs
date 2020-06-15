using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using NuTrello.Models;
using NuTrello.Data.Repository;

namespace NuTrello.Pages
{
    public class IndexModel : PageModel
    {

        // Här ska listan på bräden genereras om bräden finns
        // skall ta in alt. generera ett id som vi sedan appendar till boards ex. boards/{id}

        //random variable to vizualise an existing board
        //public List<string> boards =  new List<string>{"board one", "board two", "board three", "board four", "board five", "board six"};
        public List<DbBoardModel> boards;

        private readonly IBoardRepository _boardRepo;
        private readonly IListRepository _listRepo;
        private readonly ITaskRepository _taskRepo;

        public string insertList()
        {
            return "Data has been saved";

        }

        public IndexModel(IBoardRepository boardRepository, IListRepository listRepository, ITaskRepository taskRepository)
        {
            _boardRepo = boardRepository;
            _listRepo = listRepository;
            _taskRepo = taskRepository;
        }

        public void OnGet()
        {
            boards = _boardRepo.GetBoards();
        }   
    }
}

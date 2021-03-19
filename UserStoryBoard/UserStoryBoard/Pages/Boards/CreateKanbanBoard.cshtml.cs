using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Interface;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.Boards
{
    public class CreateKanbanBoardModel : PageModel
    {
        [BindProperty]
        public Board KanbanBoard { get; set; }

        private static int nextId = 0;
        //private BoardService boardService;
        public IBoards boards;

        public CreateKanbanBoardModel(IBoards repo)
        {
            boards = repo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            KanbanBoard.Id = nextId;
            nextId++;
            boards.AddBoard(KanbanBoard);

            return RedirectToPage("SelectKanbanBoard");
        }
    }
}

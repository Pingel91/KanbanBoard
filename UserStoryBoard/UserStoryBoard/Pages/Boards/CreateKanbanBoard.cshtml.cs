using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.Boards
{
    public class CreateKanbanBoardModel : PageModel
    {
        [BindProperty]
        public Board KanbanBoard { get; set; }

        private BoardService boardService;

        public CreateKanbanBoardModel(BoardService boardService)
        {
            this.boardService = boardService;
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
            boardService.AddBoard(KanbanBoard);

            return RedirectToPage("SelectKanbanBoard");
        }
    }
}

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
    public class EditKanbanBoardModel : PageModel
    {
        private BoardService boardService;

        [BindProperty]
        public Board KanbanBoard { get; set; }

        public EditKanbanBoardModel(BoardService bService)
        {
            this.boardService = bService;
        }

        public IActionResult OnGet(int id)
        {
            KanbanBoard = boardService.GetBoard(id);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            boardService.UpdateBoard(KanbanBoard);

            return RedirectToPage("SelectKanbanBoard");
        }
    }
}

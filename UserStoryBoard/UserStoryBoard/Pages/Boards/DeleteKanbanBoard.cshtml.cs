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
    public class DeleteKanbanBoardModel : PageModel
    {
        [BindProperty]
        public Board Board { get; set; }


        private BoardService boardService;

        public DeleteKanbanBoardModel(BoardService boardService)
        {
            this.boardService = boardService;
        }

        public IActionResult OnGet(string name)
        {
            Board = boardService.GetKanbanBoard(name);
            return Page();
        }

        public IActionResult OnPost()
        {
            boardService.DeleteKanbanBoard(Board);
            return RedirectToPage("KanbanBoard");
        }
    }
}
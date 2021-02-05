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
    public class CreateBoardModel : PageModel
    {
        [BindProperty]
        public Board KanbanBoard { get; set; }
<<<<<<< HEAD

        private BoardService boardService;

        public CreateBoardModel(BoardService boardService)
        {
            this.boardService = boardService;
        }
=======
>>>>>>> 7a772f1c05ac0459b42cc345e247424cce11c148

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

            return RedirectToPage("KanbanBoard");
        }
    }
}

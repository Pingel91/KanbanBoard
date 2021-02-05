using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;

namespace UserStoryBoard.Pages.Boards
{
    public class CreateKanbanBoardModel : PageModel
    {
        [BindProperty]
        public Board KanbanBoard { get; set; }

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

            return RedirectToPage("KanbanBoard");
        }
    }
}

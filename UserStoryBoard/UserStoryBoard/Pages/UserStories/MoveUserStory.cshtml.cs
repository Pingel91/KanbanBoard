using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.UserStories
{
    public class MoveUserStoryModel : PageModel
    {
        private BoardService boardService;

        [BindProperty]
        public UserStory UserStory { get; set; }

        public MoveUserStoryModel(BoardService bService)
        {
            boardService = bService;
        }

        public IActionResult OnPost()
        {
            

            return Page();
        }

        public IActionResult OnGet(int id, int boardId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            UserStory = boardService.GetUserStory(id, boardId);

            UserStory.ColumnId = 2;

            boardService.UpdateUserStory(UserStory, UserStory.BoardId);

            string page = "../Boards/KanbanBoard/" + UserStory.BoardId;
            return RedirectToPage(page);
<<<<<<< HEAD
=======
        }

        public void OnGet()
        {
            Console.WriteLine("Get");
>>>>>>> 58814dfe5652f570d8461a1202b85b580792590a
        }
    }
}

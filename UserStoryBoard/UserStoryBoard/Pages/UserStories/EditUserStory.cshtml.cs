using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.UserStories
{
    public class EditUserStoryModel : PageModel
    {
        private BoardService boardService;

        [BindProperty]
        public UserStory UserStory { get; set; }

        public EditUserStoryModel(BoardService bService)
        {
            boardService = bService;
        }

        public IActionResult OnGet(int id, int boardId)
        {
            UserStory = boardService.GetUserStory(id, boardId);

            return Page();
        }

        public IActionResult OnPost(int id, int boardId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            boardService.UpdateUserStory(UserStory, UserStory.BoardId);

            return Redirect("~/Boards/KanbanBoard/" + boardId);
        }
    }
}

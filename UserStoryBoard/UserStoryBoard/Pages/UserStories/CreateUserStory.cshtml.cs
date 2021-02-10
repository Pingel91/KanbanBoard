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
    public class CreateUserStoryModel : PageModel
    {
        [BindProperty] 
        public UserStory UserStory { get; set; }

        public int boardId;
        private BoardService boardService;
        //private UserStoryService userStoryService;

        public CreateUserStoryModel(BoardService bService)
        {
            boardService = bService;
        }

        public IActionResult OnGet(int id)
        {
            boardId = id;
            return Page();
        }

        //public IActionResult OnPost()
        //{
        //    UserStory.BoardId = boardId;

        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    boardService.AddUserStory(UserStory, UserStory.BoardId);

        //    return RedirectToPage("../Boards/KanbanBoard");
        //}

        public IActionResult OnPostLate()
        {
            UserStory.BoardId = boardId;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            boardService.AddUserStory(UserStory, UserStory.BoardId);

            return Redirect("~/Boards/KanbanBoard/" + boardId);
        }
    }
}

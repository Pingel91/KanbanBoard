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

        public int BoardId;
        private BoardService boardService;
        //private UserStoryService userStoryService;

        public CreateUserStoryModel(BoardService bService)
        {
            boardService = bService;
        }

        public IActionResult OnGet(int id)
        {
            BoardId = id;
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            BoardId = id;
            UserStory.BoardId = id;

            if (!ModelState.IsValid)
            {
                return Page();
            }
            boardService.AddUserStory(UserStory, id);

            return Redirect("~/Boards/KanbanBoard/" + id);
        }
    }
}

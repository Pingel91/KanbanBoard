using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Interface;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.UserStories
{
    public class CreateUserStoryModel : PageModel
    {
        [BindProperty] 
        public UserStory UserStory { get; set; }

        public int BoardId;
        // private BoardService boardService;
        IBoards boards;
        //private JsonFileUserStoryService userStoryService;
        //private UserStoryService userStoryService;

        private bool inBacklog;

        public CreateUserStoryModel(IBoards repo)
        {
            boards = repo;
            //boardService = bService;
        }

        public IActionResult OnGet(int id, bool backlog)
        {
            BoardId = id;
            inBacklog = backlog;

            return Page();
        }

        public IActionResult OnPost(int id, bool backlog)
        {
            BoardId = id;
            UserStory.BoardId = id;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            boards.AddUserStory(UserStory, id, backlog);

            if (backlog)
                return Redirect("~/Backlogs/BacklogUserStory/" + id);
            else
                return Redirect("~/Boards/KanbanBoard/" + id);
        }

        public bool InBacklog()
        {
            return inBacklog;
        }
    }
}

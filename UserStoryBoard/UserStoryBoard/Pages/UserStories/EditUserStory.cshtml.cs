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
    public class EditUserStoryModel : PageModel
    {
        //private BoardService boardService;
        IBoards boards;

        [BindProperty]
        public UserStory UserStory { get; set; }

        public EditUserStoryModel(IBoards repo)
        {
            boards = repo;
        }

        public IActionResult OnGet(int id, int boardId)
        {
            UserStory = boards.GetUserStory(id, boardId);

            return Page();
        }

        public IActionResult OnPost(int id, int boardId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            boards.UpdateUserStory(UserStory, boardId);

            return Redirect("~/Boards/KanbanBoard/" + boardId);
        }
    }
}

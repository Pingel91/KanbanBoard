using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Interface;
using UserStoryBoard.Models;
using UserStoryBoard.Services;


namespace UserStoryBoard.Pages
{
    public class DeleteUserStoryModel : PageModel
    {
        
        [BindProperty]
        public UserStory UserStory { get; set; }

        public bool IsBacklog;

        // private BoardService boardService;
        IBoards boards;

        public DeleteUserStoryModel(IBoards repo)
        {
            boards = repo;
        }

        public void OnGet(int id, int boardId, bool backlog)
        {
            IsBacklog = backlog;

            UserStory = boards.GetUserStory(id, boardId, backlog);
        }

        public IActionResult OnPost(int id, int boardId, bool backlog)
        {
            boards.DeleteUserStory(id, boardId, backlog);

            if (backlog == false)
                return Redirect("~/Boards/KanbanBoard/" + boardId + "/" + backlog);
            else
                return Redirect("~/Backlogs/BacklogUserStory/" + boardId + "/" + backlog);
        }
    }
}

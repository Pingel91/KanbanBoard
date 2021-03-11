using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Interface;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.UserStories
{
    public class MoveUserStoryModel : PageModel
    {
        IBoards boards;
       // private BoardService boardService;

        [BindProperty]
        public UserStory UserStory { get; set; }

        public MoveUserStoryModel(IBoards repo)
        {
            boards = repo;
        }

        public void OnPost(int id, int boardId, int userId, bool backlog)
        {
            Debug.WriteLine("Post");

            UserStory = boards.GetUserStory(id, boardId, backlog);
            UserStory.ColumnId = userId;
            boards.UpdateUserStory(UserStory, boardId, backlog);
        }

        public void OnGet(int id, int boardId, int userId, bool backlog)
        {
            Debug.WriteLine("Get");

            if (!ModelState.IsValid)
            {
                
            }

            UserStory = boards.GetUserStory(id, boardId, backlog);
            UserStory.ColumnId = userId;
            boards.UpdateUserStory(UserStory, boardId, backlog);
        }
    }
}

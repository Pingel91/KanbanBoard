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

        public void OnPost(int id, int boardId, int userId)
        {
            Debug.WriteLine("Post");

            UserStory = boardService.GetUserStory(id, boardId);
            UserStory.ColumnId = userId;
            boardService.UpdateUserStory(UserStory, UserStory.BoardId);
        }

        public void OnGet(int id, int boardId, int userId)
        {
            Debug.WriteLine("Get");

            if (!ModelState.IsValid)
            {
                
            }

            UserStory = boardService.GetUserStory(id, boardId);
            UserStory.ColumnId = userId;
            boardService.UpdateUserStory(UserStory, UserStory.BoardId);
        }
    }
}

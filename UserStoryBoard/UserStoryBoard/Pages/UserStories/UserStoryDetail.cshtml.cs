using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages
{
    public class UserStoryDetailModel : PageModel
    {
        [BindProperty] 
        public UserStory UserStory { get; set; }

        public List<UserStory> UserStories { get; private set; }
        private BoardService boardService;

        

        public UserStoryDetailModel(BoardService bService)
        {
            boardService = bService;
        }
        public void OnGet(int id, int boardId)
        {
            UserStories = boardService.GetUserStories(boardId);
            UserStory = boardService.GetUserStory(id, boardId);
        }
    }
}

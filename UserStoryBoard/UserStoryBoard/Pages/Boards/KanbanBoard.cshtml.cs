using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Services;
using UserStoryBoard.Models;

namespace UserStoryBoard.Pages
{
    public class KanbanBoardModel : PageModel
    {
        public int currentId = 0;

        private BoardService boardService;
        private UserStoryService userStoryService;

        public List<UserStory> UserStories { get; private set; }
        public List<Board> KanbanBoards;

        public KanbanBoardModel(UserStoryService uSService, BoardService bService)
        {
            boardService = bService;
            userStoryService = uSService;
        }
        public void OnGet(int id)
        {
            KanbanBoards = boardService.GetAllBoards();
            UserStories = userStoryService.GetUserStories(); // SELECTS THE SAME USER STORIES FOR ALL BOARDS - NEEDS TO GO THROUGH THE NEW BoardService
            currentId = id;
        }

        public void OnPost()
        {

        }
    }
}

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

        private UserStoryService userStoryService;

        public List<UserStory> UserStories { get; private set; }
        public List<Board> KanbanBoards = new List<Board>()
        {
            new Board("Kanban Board 1"),
            new Board("Caspars Test Board"),
            new Board("Board")
        };

        public KanbanBoardModel(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }
        public void OnGet(int id)
        {
            UserStories = userStoryService.GetUserStories();
            currentId = id;
        }
    }
}

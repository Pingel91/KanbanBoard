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
            new Board("Kanban Board 1", new List<string>() {"To Do", "Doing", "Done"}, 3),
            new Board("Caspars Test Board", new List<string>() {"To Do", "Doing", "Done"}, 3),
            new Board("Board", new List<string>() {"To Do", "Doing", "Done"}, 3)
        };

        public KanbanBoardModel(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }
        public void OnGet(int id)
        {
            UserStories = userStoryService.GetUserStories(); // SELECTS THE SAME USER STORIES FOR ALL BOARDS - NEEDS TO GO THROUGH THE NEW BoardService
            currentId = id;
        }
    }
}

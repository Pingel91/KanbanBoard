using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages
{
    public class KanbanBoardModel : PageModel
    {
        public int currentId = 0;

        private BoardService boardService;

        public List<UserStory> UserStories { get; private set; }
        public List<Board> KanbanBoards;

        public KanbanBoardModel(BoardService bService)
        {
            boardService = bService;
        }
        public void OnGet(int id)
        {
            KanbanBoards = boardService.GetAllBoards();
            UserStories = boardService.GetUserStories(id);
            currentId = id;
        }

        public void OnPost()
        {

        }
    }
}

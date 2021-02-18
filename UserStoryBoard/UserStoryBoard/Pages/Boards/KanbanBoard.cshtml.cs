using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using UserStoryBoard.Interface;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages
{
    public class KanbanBoardModel : PageModel
    {
        //private BoardService boardService;
        IBoards boards;
        //public Board CurrentBoard { get; set; }

        public List<UserStory> UserStories { get; private set; }

        private int boardId;

        public KanbanBoardModel(IBoards repo)
        {
            boards = repo;
            //boardService = bService;
        }
        public IActionResult OnGet(int id)
        {
            boardId = id;

            return Page();
        }

        // For refreshing the page when moving a card
        public IActionResult OnGetColumn(int boardId, int userStoryId, int column)
        {
            UserStory updated = boards.GetUserStory(userStoryId, boardId);

            int result = updated.ColumnId + column;
            if (result > -1 && result < Board.Columns)
            {
                updated.ColumnId = result; // FUCK THIS
                boards.UpdateUserStory(updated, boards.GetBoard(boardId).Id);
            }

            return Page();
        }

        public Board GetCurrentBoard()
        {
            return boards.GetBoard(boardId);
        }
        public List<UserStory> GetUserStories()
        {
            return boards.GetUserStories(boardId);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using UserStoryBoard.Interface;
using UserStoryBoard.Models;

namespace UserStoryBoard.Pages
{
    public class KanbanBoardModel : PageModel
    {
        //private BoardService boardService;
        IBoards boards;

        [BindProperty]
        public UserStory UserStory { get; set; }


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
        public IActionResult OnGetColumn(int boardId, int userStoryId, int column, bool backlog)
        {
            UserStory updated = boards.GetUserStory(userStoryId, boardId, backlog);

            int result = updated.ColumnId + column;
            if (result > -1 && result < Board.Columns)
            {
                updated.ColumnId = result; // FUCK THIS
                boards.UpdateUserStory(updated, boards.GetBoard(boardId).Id, backlog);
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

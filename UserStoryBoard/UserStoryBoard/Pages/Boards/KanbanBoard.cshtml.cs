using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages
{
    public class KanbanBoardModel : PageModel
    {
        private BoardService boardService;
        //public Board CurrentBoard { get; set; }

        public List<UserStory> UserStories { get; private set; }
        public List<Board> KanbanBoards;

        private int boardId;

        public KanbanBoardModel(BoardService bService)
        {
            boardService = bService;
        }
        public IActionResult OnGet(int id)
        {
            boardId = id;
            GetData(id);

            return Page();
        }

        // For refreshing the page when moving a card
        public IActionResult OnGetColumn(int boardId, int userStoryId, int column)
        {
            GetData(boardId);

            UserStory updated = boardService.GetUserStory(userStoryId, boardId);

            int result = updated.ColumnId + column;
            if (result > -1 && result < GetCurrentBoard().Columns)
            {
                updated.ColumnId = result; // FUCK THIS
                boardService.UpdateUserStory(updated, boardService.GetBoard(boardId).Id);
            }

            return Page();
        }

        private void GetData(int id)
        {
            //CurrentBoard = boardService.GetBoard(id);
            KanbanBoards = boardService.GetAllBoards();
            //UserStories = boardService.GetUserStories(id);
        }

        public Board GetCurrentBoard()
        {
            return boardService.GetBoard(boardId);
        }
        public List<UserStory> GetUserStories()
        {
            return boardService.GetUserStories(boardId);
        }
    }
}

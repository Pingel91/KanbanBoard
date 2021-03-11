using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Interface;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages
{
    public class UserStoryDetailModel : PageModel
    {
        [BindProperty] 
        public UserStory UserStory { get; set; }

        public bool IsBacklog;
        public int ColumnsToDraw;

        public List<UserStory> UserStories { get; private set; }
        // private BoardService boardService;
        IBoards boards;

        //public Board CurrentBoard { get; set; }

        private int boardId;

        public UserStoryDetailModel(IBoards repo)
        {
            boards = repo;
        }
        public void OnGet(int id, int boardId, bool backlog)
        {
            IsBacklog = backlog;
            ColumnsToDraw = backlog ? Backlog.Columns : Board.Columns; // If backlog is true, use backlog columns, else use board columns. This is just shorthand for if/else.

            this.boardId = boardId;

            UserStories = boards.GetUserStories(boardId);
            UserStory = boards.GetUserStory(id, boardId, backlog);
        }

        public Board GetCurrentBoard()
        {
            return boards.GetBoard(boardId);
        }
        public List<UserStory> GetUserStories()
        {
            if (IsBacklog == false)
                return boards.GetUserStories(boardId);
            else
                return boards.GetUserStoriesInBacklog(boardId);
        }
    }
}

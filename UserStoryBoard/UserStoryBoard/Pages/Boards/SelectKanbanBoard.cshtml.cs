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
    public class SelectKanbanBoardModel : PageModel
    {
        private BoardService boardService;
        public List<Board> KanbanBoards;

        public SelectKanbanBoardModel(BoardService bService)
        {
            this.boardService = bService;
        }

        public void OnGet()
        {
            KanbanBoards = boardService.GetAllBoards();
        }
    }
}

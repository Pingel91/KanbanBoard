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
    public class SelectKanbanBoardModel : PageModel
    {
        //private BoardService boardService;
        IBoards boards;
        public List<Board> KanbanBoards;

        public SelectKanbanBoardModel(IBoards repo)
        {
            //this.boardService = bService;
            boards = repo;
        }

        public void OnGet()
        {
            KanbanBoards = boards.GetAllBoards();
        }
    }
}

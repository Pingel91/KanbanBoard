using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Interface;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.Boards
{
    public class EditKanbanBoardModel : PageModel
    {
        //private BoardService boardService;
        IBoards boards;

        [BindProperty]
        public Board KanbanBoard { get; set; }

        public EditKanbanBoardModel(IBoards repo)
        {
            boards = repo;
            //this.boardService = bService;
        }

        public IActionResult OnGet(int boardId)
        {
            KanbanBoard = boards.GetBoard(boardId);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            boards.UpdateBoard(KanbanBoard);

            return RedirectToPage("SelectKanbanBoard");
        }
    }
}

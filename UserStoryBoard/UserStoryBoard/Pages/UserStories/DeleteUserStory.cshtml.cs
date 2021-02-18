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
    public class DeleteUserStoryModel : PageModel
    {
        
        [BindProperty]
        public UserStory UserStory { get; set; }
        

       // private BoardService boardService;
        IBoards boards;

        public DeleteUserStoryModel(IBoards repo)
        {
            boards = repo;
        }
        public void OnGet(int id, int boardId)
        {
            UserStory = boards.GetUserStory(id, boardId);
            
        }

        public IActionResult OnPost(int id, int boardId)
        {
            boards.DeleteUserStory(id, boardId);
            return Redirect("~/Boards/KanbanBoard/" + boardId);
        }
    }
}

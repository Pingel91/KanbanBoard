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
    public class DeleteUserStoryModel : PageModel
    {
        
        [BindProperty]
        public UserStory UserStory { get; set; }
        

        private BoardService boardService;

        public DeleteUserStoryModel(BoardService bService)
        {
            boardService = bService;
        }
        public void OnGet(int id, int boardId)
        {
            UserStory = boardService.GetUserStory(id, boardId);
        }

        public IActionResult OnPost()
        {
            UserStory deletedUserStory = boardService.DeleteUserStory(UserStory.Id, UserStory.BoardId);
            string page = "../Boards/KanbanBoard/" + UserStory.BoardId;
            return RedirectToPage(page);
        }
    }
}

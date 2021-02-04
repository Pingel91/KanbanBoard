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
        public Models.UserStory UserStory { get; set; }
        

        private UserStoryService userStoryService;

        public DeleteUserStoryModel(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }
        public void OnGet(int id)
        {
            UserStory = userStoryService.GetUserStory(id);
        }

        public IActionResult OnPost()
        {
            UserStory deletedUserStory = userStoryService.DeleteUserStory(UserStory.Id);
            return RedirectToPage("UserStories");
        }
    }
}

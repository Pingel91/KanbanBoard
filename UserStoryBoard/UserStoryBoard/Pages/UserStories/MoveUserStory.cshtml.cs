using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.UserStories
{
    public class MoveUserStoryModel : PageModel
    {
        private UserStoryService userStoryService;

        [BindProperty]
        public UserStory UserStory { get; set; }

        public MoveUserStoryModel(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }

        public IActionResult OnPost(int id)
        {
            Console.WriteLine("Post");

            UserStory = userStoryService.GetUserStory(id);

            UserStory.ColumnId = 2;

            userStoryService.UpdateUserStory(UserStory);

            return RedirectToPage("UserStories");
        }

        public void OnGet()
        {
            Console.WriteLine("Get");
        }
    }
}

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
    public class EditUserStoryModel : PageModel
    {
        private UserStoryService userStoryService;

        [BindProperty]
        public UserStory UserStory { get; set; }
         

        public EditUserStoryModel(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }

        public IActionResult OnGet(int id)
        {
            UserStory = userStoryService.GetUserStory(id);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            userStoryService.UpdateUserStory(UserStory);

            return RedirectToPage("UserStories");
        }
    }
}

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
    public class UserStoriesModel : PageModel
    {
        private UserStoryService userStoryService;

        public List<UserStory> UserStories { get; private set; }

        public UserStoriesModel(UserStoryService userStoryService)
        {
            this.userStoryService = userStoryService;
        }
        public void OnGet()
        {
            UserStories = userStoryService.GetUserStories();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.User
{
    public class DeleteUserModel : PageModel
    {
        [BindProperty]
        public User1 user { get; set; }

        private UserService userService;

        public DeleteUserModel(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult OnGet(int id)
        {
            user = userService.GetUser(id);
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            userService.DeleteUser(id);
            return RedirectToPage("GetUsers");
        }
    }
}

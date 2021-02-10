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
    public class CreateUserModel : PageModel
    {
        [BindProperty]
        public User1 User { get; set; }

        private UserService userService;

        public CreateUserModel(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            userService.AddUser(User);

            return RedirectToPage("GetUsers");
        }
    }
}

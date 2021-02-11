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
    public class EditUserModel : PageModel
    {
        private UserService userService;

        [BindProperty]
        public User1 User { get; set; }

        public EditUserModel(UserService userService)
        {
            this.userService = userService;
        }

        public IActionResult OnGet(int id)
        {
            User = userService.GetUser(id);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            userService.UpdateUser(User);

            return RedirectToPage("GetUsers");
        }
    }
}

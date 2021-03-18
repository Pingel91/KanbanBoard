using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.Admin
{
    [Authorize(Roles = "admin")]
    public class CreateUserModel : PageModel
    {
        [BindProperty] public string UserName { get; set; }
        [BindProperty,DataType(DataType.Password)]
        public string Password { get; set; }

        private UserService userService;
        private PasswordHasher<string> passwordHasher;

        public CreateUserModel(UserService userService, PasswordHasher<string> passwordHasher)
        {
            this.userService = userService;
            this.passwordHasher = passwordHasher;

        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            userService.AddUser(new User(UserName, passwordHasher.HashPassword(null, Password)));
            return RedirectToPage("/Index");
        }
    }
}

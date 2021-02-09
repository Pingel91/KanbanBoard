using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Services;
using UserStoryBoard.Models;


namespace UserStoryBoard.Pages.User
{
    public class GetUsersModel : PageModel
    {
        private UserService userService;

        public List<User1> Users { get; private set; }

        public GetUsersModel(UserService userService)
        {
            this.userService = userService;
        }
        public void OnGet()
        {
            Users = userService.GetUsers();
        }
    }
}

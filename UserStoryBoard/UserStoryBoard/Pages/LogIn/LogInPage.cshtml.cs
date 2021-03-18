using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.LogIn
{
    public class LogInPageModel : PageModel
    {
        public static User LoggedInUser { get; set; } = null;

        [BindProperty]
        public string UserName { get; set; }
        [BindProperty, DataType(DataType.Password)]
        public string Password { get; set; }
        public string Message { get; set; }

        private UserService _userService;

        public LogInPageModel(UserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {


            List<User> users = _userService.GetUsers();
            foreach (User user in users)
            {

                if (UserName == user.UserName )
                {
                    //var passwordHasher = new PasswordHasher<string>();
                   // if (passwordHasher.VerifyHashedPassword(null, user.Password, Password) == PasswordVerificationResult.Success)
                    
                        LoggedInUser = user;

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, UserName)

                        };
                        if (UserName == "admin") claims.Add(new Claim(ClaimTypes.Role, "admin"));
                        var claimsIdentity =
                            new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity));
                        return RedirectToPage("/Index");
                    

                }

            }

            Message = "Invalid attempt";
            return Page();
        }
    }
}

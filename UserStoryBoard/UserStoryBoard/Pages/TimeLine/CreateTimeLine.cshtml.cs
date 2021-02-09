using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages.SizeMeUp
{
    public class CreateTimeLineModel : PageModel
    {
        //[BindProperty] 
        //public TimeLine TimeLin { get; set; }

        //private TImeLineServices tImeLineServices;

        //public CreateTimeLineModel(TImeLineServices tImeLineServices)
        //{
        //    this.tImeLineServices = tImeLineServices;
        //}
        //public void OnGet()
        //{
        //    return Page();
        //}

        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    tImeLineServices.AddTimeLine(TimeLine);
        //    return RedirectToPage("CreateTimeLine");
        //}
    }
}

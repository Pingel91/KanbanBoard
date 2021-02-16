using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Models;

namespace UserStoryBoard.Pages._4LevelsTests
{
    public class SystemTestModel : PageModel
    {
        public List<Test> SystemTests { get; private set; }

        
        public void OnGet()
        {
            //SystemTests = TestsService.GetTests();
        }
    }
}

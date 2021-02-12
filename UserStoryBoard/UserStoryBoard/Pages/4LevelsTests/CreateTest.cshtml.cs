using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserStoryBoard.Pages._4LevelsTests;
using UserStoryBoard.Models;
using UserStoryBoard.Services;

namespace UserStoryBoard.Pages
{
    public class CreateTestModel : PageModel
    {
        private TestsService testsService;
        private List<Models.Test> systemTests;
        public Models.Test Test { get; set; }

        public CreateTestModel(List<Test> systemTests, Test test, TestsService Tservice)
        {
            testsService = Tservice;
            this.systemTests = systemTests;
            Test = testsService.GetTest().ToList();
        }
        public void OnGet()
        {

        }
    }
}

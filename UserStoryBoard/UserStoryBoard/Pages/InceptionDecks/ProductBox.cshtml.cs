using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;

namespace UserStoryBoard.Pages.InceptionDecks
{
    public class ProductBoxModel : PageModel
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductBoxModel(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public string PhotoPath
        {
            get
            {
                return "~/Images/product box.jpg";
            }
            set
            {

            }
        }
        [BindProperty]
        public IFormFile Photo { get; set; }

        public IActionResult OnPost()
        {
            if (Photo != null)
            {
                if (PhotoPath != null)
                {
                    string filePath = Path.Combine(webHostEnvironment.WebRootPath, "Images", PhotoPath);
                    // (det her crasher lige nu pga. pathing problemer) System.IO.File.Delete(filePath);
                }

                PhotoPath = ProcessUploadedFile();
            }

            return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
        public void OnGet()
        {
        }
    }
}

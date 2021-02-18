using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using UserStoryBoard.Helpers;
using UserStoryBoard.Models;

namespace UserStoryBoard.Services
{
    public class BacklogJsonService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public BacklogJsonService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Backlogs.json"); }
        }

        public IEnumerable<Backlog> GetJsonBacklogs()
        {
            try { return JsonHelper.ReadBacklogs(JsonFileName); }
            catch { return null; }
        }

        public void SaveJsonBacklogs(List<Backlog> backlogs)
        {
            try
            {
                JsonHelper.WriteBacklogs(backlogs, JsonFileName);
                Debug.WriteLine($"Successfully saved Boards list: {JsonFileName}");
            }
            catch (ArgumentException aExc)
            {
                Console.WriteLine(aExc.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Helpers;
using UserStoryBoard.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Diagnostics;

namespace UserStoryBoard.Services
{
    public class JsonFileBoards
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileBoards(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Boards.json"); }
        }

        public IEnumerable<Board> GetJsonBoards()
        {
            try { return JsonHelper.ReadBoards(JsonFileName); }
            catch { return null; }
        }

        public void SaveJsonBoards(List<Board> boards)
        {
            try
            {
                JsonHelper.WriteBoards(boards, JsonFileName);
                Debug.WriteLine($"Successfully saved Boards list: {JsonFileName}");
            }
            catch (ArgumentException aExc)
            {
                Console.WriteLine(aExc.Message);
            }
        }
    }
}

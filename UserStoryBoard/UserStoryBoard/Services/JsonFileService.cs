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
    public class JsonFileService<T>
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", typeof(T) + ".json"); }
        }

        public IEnumerable<T> GetJsonObjects()
        {
            try { return JsonHelper<T>.ReadObjects(JsonFileName); }
            catch { return null; }
        }

        public void SaveJsonObjects(List<T> objects)
        {
            try
            {
                JsonHelper<T>.WriteObjects(objects, JsonFileName);
                Debug.WriteLine($"Successfully saved Boards list: {JsonFileName}");
            }
            catch (ArgumentException aExc)
            {
                Console.WriteLine(aExc.Message);
            }
        }
    }
}

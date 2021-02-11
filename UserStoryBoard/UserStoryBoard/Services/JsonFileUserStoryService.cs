//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text.Json;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Hosting;
//using UserStoryBoard.Models;
//using UserStoryBoard.Helpers;
//using System.Diagnostics;

//namespace UserStoryBoard.Services
//{
//    public class JsonFileUserStoryService
//    {
//        public IWebHostEnvironment WebHostEnvironment { get; }

//        public JsonFileUserStoryService(IWebHostEnvironment webHostEnvironment)
//        {
//            WebHostEnvironment = webHostEnvironment;
//        }

//        private string JsonFileName
//        {
//            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "UserStory.json"); }
//        }

//        public IEnumerable<UserStory> GetJsonUserStory()
//        {
//            try { return JsonHelper.ReadUserStory(JsonFileName); }
//            catch { return null; }

//            //using var jsonFileReader = File.OpenText(JsonFileName);
//            //return JsonSerializer.Deserialize<UserStory[]>(jsonFileReader.ReadToEnd());
//        }

//        public void SaveJsonUserStories(List<UserStory> userStories) 
//        {
//            try 
//            { 
//                JsonHelper.WriteUserStories(userStories, JsonFileName);
//                Debug.WriteLine($"Successfully saved User Stories list: {JsonFileName}");
//            }
//            catch ( ArgumentException aExc ) 
//            { 
//                Console.WriteLine(aExc.Message); 
//            }

//            //using var jsonFileWriter = File.Create(JsonFileName);
//            //var jsonWriter = new Utf8JsonWriter(jsonFileWriter, new JsonWriterOptions()
//            //{
//            //    SkipValidation = false,
//            //    Indented = true
//            //});
//            //JsonSerializer.Serialize(jsonWriter, userStories.ToArray());
//        }
//    }
//}

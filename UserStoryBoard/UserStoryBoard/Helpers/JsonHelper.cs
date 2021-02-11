using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;
using System.IO;
using Newtonsoft.Json;

namespace UserStoryBoard.Helpers
{
    public class JsonHelper
    {
        public static List<Board> ReadCourse(string filename)
        {
            List<Board> jsonObject = new List<Board>();

            if (File.Exists(filename))
            {
                try
                {
                    string jsonString = File.ReadAllText(filename);
                    jsonObject = JsonConvert.DeserializeObject<List<Board>>(jsonString);
                }
                catch { throw new ArgumentException($"FILE WITH NAME '{filename}' DOESN'T EXIST"); }
            }

            return jsonObject;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserStoryBoard.Models;

namespace UserStoryBoard.Helpers
{
    public class JsonHelper
    {
        public static List<Board> ReadBoards(string filename)
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
        public static bool WriteBoards(List<Board> boards, string filename)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(boards,
                    Formatting.Indented);

                File.WriteAllText(filename, jsonString);

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}

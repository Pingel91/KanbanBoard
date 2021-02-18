using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UserStoryBoard.Models;

namespace UserStoryBoard.Helpers
{
    public class JsonHelper
    {
        public static void ClearFiles(string filename)
        {
            if (File.Exists(filename))
            {
                try
                {
                    File.Delete(filename);
                }
                catch { throw new ArgumentException($"FILE WITH NAME '{filename}' DOESN'T EXIST"); }
            }
        }

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
        public static List<Backlog> ReadBacklogs(string filename)
        {
            List<Backlog> jsonObject = new List<Backlog>();

            if (File.Exists(filename))
            {
                try
                {
                    string jsonString = File.ReadAllText(filename);
                    jsonObject = JsonConvert.DeserializeObject<List<Backlog>>(jsonString);
                }
                catch { throw new ArgumentException($"FILE WITH NAME '{filename}' DOESN'T EXIST"); }
            }

            return jsonObject;
        }

        public static List<UserStory> ReadUserStory(string filename)
        {
            List<UserStory> jsonObject = new List<UserStory>();

            if (File.Exists(filename))
            {
                try
                {
                    string jsonString = File.ReadAllText(filename);
                    jsonObject = JsonConvert.DeserializeObject<List<UserStory>>(jsonString);
                }
                catch { throw new ArgumentException($"FILE WITH NAME '{filename}' DOESN'T EXIST"); }
            }

            return jsonObject;
        }

        public static bool WriteBoards(List<Board> boards, string filename)
        {
            try
            {
                // DELETE EVERYTHING (⊙_⊙;)
                ClearFiles(filename);

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
        
        public static bool WriteBacklogs(List<Backlog> backlogs, string filename)
        {
            try
            {
                // DELETE EVERYTHING (⊙_⊙;)
                ClearFiles(filename);

                string jsonString = JsonConvert.SerializeObject(backlogs,
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

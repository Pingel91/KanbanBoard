using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using UserStoryBoard.Models;

namespace UserStoryBoard.Helpers
{
    public class JsonHelper<T>
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

        public static List<T> ReadObjects(string filename)
        {
            List<T> jsonObject = new List<T>();

            if (File.Exists(filename))
            {
                try
                {
                    string jsonString = File.ReadAllText(filename);
                    jsonObject = JsonConvert.DeserializeObject<List<T>>(jsonString);
                }
                catch { throw new ArgumentException($"FILE WITH NAME '{filename}' DOESN'T EXIST"); }
            }

            return jsonObject;
        }

        public static bool WriteObjects(List<T> objects, string filename)
        {
            try
            {
                // DELETE EVERYTHING (⊙_⊙;)
                ClearFiles(filename);

                string jsonString = JsonConvert.SerializeObject(objects, Formatting.Indented);

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

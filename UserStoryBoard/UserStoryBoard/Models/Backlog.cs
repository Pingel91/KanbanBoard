using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class Backlog : CardTemplate
    {
        public static int Columns { get; set; } = 4;
        public static string[] ColumnNames { get; set; } = new string[] { "Lav ", "Mellem", "Høj", "Haster" };
        public List<UserStory> userStoriesInBacklog { get; set; } = new List<UserStory>();

        private static int nextId = 0;

        public Backlog()
        {
        }

        public Backlog(string name) : base(name)
        {
            Id = nextId++;
            CreationDate = DateTime.Now;
        }

        public Backlog(string name, string descr) : base(name)
        {
            Id = nextId++;
            //Columns = cols;
            Description = descr;

            CreationDate = DateTime.Now;
        }
    }
}

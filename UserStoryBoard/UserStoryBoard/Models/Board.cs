using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;
using System.Diagnostics;

namespace UserStoryBoard.Models
{
    public class Board : CardTemplate
    {
        public static int Columns { get; set; } = 4;
        public static string[] ColumnNames { get; set; } = new string[] { "To Do", "Doing", "To Test", "Done" };
        public List<UserStory> UserStoriesOnBoard { get; set; } = new List<UserStory>();
        public Backlog BoardBacklog { get; private set; } = new Backlog();

        private static int nextId = 0;

        public Board ()
        {
        }

        public Board(string name) : base (name)
        {
            Id = nextId++;
            CreationDate = DateTime.Now;
        }

        public Board(string name, string descr) : base(name)
        {
            Id = nextId++;
            //Columns = cols;
            Description = descr;

            BoardBacklog.Name = name;

            CreationDate = DateTime.Now;
        }
    }
}

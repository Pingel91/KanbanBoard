using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;

namespace UserStoryBoard.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string BoardName { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Columns { get; set; }
        public List<string> ColumnNames { get; set; }
        public List<UserStory> userStoriesOnBoard { get; set; } = new List<UserStory>();

        private static int nextId = 0;

        public Board()
        {
            Id = nextId++;

            CreationDate = DateTime.Now;
        }

        public Board(string name)
        {
            Id = nextId++;
            BoardName = name;

            CreationDate = DateTime.Now;
        }

        public Board(string name, List<string> colNames, int cols, string descr)
        {
            Id = nextId++;
            BoardName = name;
            Columns = cols;
            ColumnNames = colNames;
            Description = descr;

            CreationDate = DateTime.Now;
        }
    }
}

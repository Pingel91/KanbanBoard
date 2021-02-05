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
        public int Columns { get; set; }
        public List<string> ColumnNames { get; set; }
        public List<UserStory> userStoriesOnBoard { get; set; }

        private static int nextId = 1;

        public Board()
        {
            Id = nextId++;
        }

        public Board(string name)
        {
            BoardName = name;
        }

        public Board(string name, List<string> colNames, int cols)
        {
            Id = nextId++;
            BoardName = name;
            Columns = cols;
            ColumnNames = colNames;
        }
    }
}

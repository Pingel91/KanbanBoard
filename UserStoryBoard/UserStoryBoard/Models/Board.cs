using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;

namespace UserStoryBoard.Models
{
    public class Board
    {
        public string BoardName { get; set; }
        public int Columns { get; set; }
        public List<string> ColumnNames { get; set; }
        public List<UserStory> userStoriesOnBoard { get; set; }

        public Board()
        { }

        public Board(string name)
        {
            BoardName = name;
        }

        public Board(string name, List<string> colNames, int cols)
        {
            BoardName = name;
            Columns = cols;
            ColumnNames = colNames;
        }
    }
}

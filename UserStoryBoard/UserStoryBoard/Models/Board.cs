using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class Board
    {
        public string Name { get; set; }

        public Board()
        { }

        public Board(string name)
        {
            Name = name;
        }
    }
}

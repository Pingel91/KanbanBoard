using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class KanbanBoard
    {
        public string Title { get; set; }
        public List<UserStory> toDo = new List<UserStory>();
        public List<UserStory> doing = new List<UserStory>();
        public List<UserStory> done = new List<UserStory>();

        public KanbanBoard()
        {

        }

        public KanbanBoard(string title)
        {
            Title = title;
        }
    }
}

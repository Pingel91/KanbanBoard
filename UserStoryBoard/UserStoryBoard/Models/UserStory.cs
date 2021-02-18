using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace UserStoryBoard.Models
{
    public class UserStory : CardTemplate
    {
        public int BusinessValue { get; set; }
        public int Priority { get; set; }
        public string StoryPoints { get; set; }

        public int BoardId { get; set; }
        public int ColumnId { get; set; }

        private static int nextId = 0;

        public UserStory()
        {
        }

        public UserStory(string name) : base (name)
        {
            Id = nextId++;
            CreationDate = DateAndTime.Now;
        }

        public UserStory(string name, string description, int businessValue, int priority, string storyPoints, int boardId, int column = 0) : base(name)
        {
            Id = nextId++;
            //Name = name;
            Description = description;
            BusinessValue = businessValue;
            CreationDate = DateAndTime.Now;
            Priority = priority;
            StoryPoints = storyPoints;
            BoardId = boardId;

            // Optional to set on creation
            ColumnId = column;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace UserStoryBoard.Models
{
    public class UserStory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BusinessValue { get; set; }
        public DateTime CreationDate { get; set; }
        public int Priority { get; set; }
        public string StoryPoints { get; set; }

        public int BoardId { get; set; }
        public int ColumnId { get; set; }

        private static int nextId = 0;

        public UserStory()
        {
            Id = nextId++;
            CreationDate = DateAndTime.Now;
        }

        public UserStory(string title, string description, int businessValue, int priority, string storyPoints, int boardId, int column = 1)
        {
            Id = nextId++;
            Title = title;
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

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

        public int Column { get; set; }

        private static int nextId = 1;

        public UserStory()
        {
            nextId++;
        }

        public UserStory(string title, string description, int businessValue, int priority, string storyPoints, int column = 1)
        {
            Id = nextId++;
            Title = title;
            Description = description;
            BusinessValue = businessValue;
            CreationDate = DateAndTime.Now;
            Priority = priority;
            StoryPoints = storyPoints;
            Column = column;
        } 
    }
}

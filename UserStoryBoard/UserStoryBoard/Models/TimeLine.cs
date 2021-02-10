using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class TimeLine
    {
        public int Id { get; set; }
        public string ProjectTitle { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int nextId = 1;
        public List<Sprint> Sprints { get; set; }

        public TimeLine(string projectTitle, DateTime startDate, DateTime endDate, List<Sprint> sprints)
        {
            Id = nextId++;
            ProjectTitle = projectTitle;
            StartDate = startDate;
            EndDate = endDate;
            Sprints = sprints;
        }
        
    }
}

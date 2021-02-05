using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class TimeLine
    {
        public string TitleOfProject { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Sprint> Sprints { get; set; }

        public TimeLine(string titleOfProject, DateTime startDate, DateTime endDate, List<Sprint> sprints)
        {
            TitleOfProject = titleOfProject;
            StartDate = startDate;
            EndDate = endDate;
            Sprints = sprints;
        }
    }
}

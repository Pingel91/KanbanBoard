using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public string SprintName { get; set; }
        public DateTime SprintStart { get; set; }
        public DateTime SprintEnd { get; set; }
        public static int nextId = 1;

        public Sprint(string sprintName, DateTime sprintStart, DateTime sprintEnd)
        {
            Id = nextId++;
            SprintName = sprintName;
            SprintStart = sprintStart;
            SprintEnd = sprintEnd;
        }

    }
}

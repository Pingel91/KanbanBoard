using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.MockData;
using UserStoryBoard.Models;

namespace UserStoryBoard.Services
{
    public class TImeLineServices
    {
        private List<Sprint> sprints;

        public TImeLineServices()
        {
            sprints = MockSprints.GetMockSprints();
        }

        public List<Sprint> GetAllSprints()
        {
            return sprints;
        }

        public Sprint GetSprint(int id)
        {
            foreach (Sprint s in sprints)
            {
                if (s.Id == id)
                    return s;
            }
            return null;
        }

        public void UpdateSprint(Sprint sprint)
        {
            if (sprint != null)
            {
                for (int s = 0; s < sprints.Count; s++)
                {
                    if (sprints[s].Id == sprint.Id)
                    {
                        sprints[s] = sprint;
                    }
                }
            }
        }

        public void AddSprint(Sprint aSprint)
        {
            sprints.Add(aSprint);
        }

    }
}

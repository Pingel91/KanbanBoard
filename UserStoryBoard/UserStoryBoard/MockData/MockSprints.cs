using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;

namespace UserStoryBoard.MockData
{
    public class MockSprints
    {
        private static List<Sprint> sprints = new List<Sprint>()
        {
            new Sprint("Sprint 1", DateTime.Today, DateTime.Now),
            new Sprint("Sprint 2", DateTime.Today, DateTime.Now),
            new Sprint("Sprint 3", DateTime.Today, DateTime.Now),
            new Sprint("Sprint 4", DateTime.Today, DateTime.Now)

        };

        public static List<Sprint> GetMockSprints()
        {
            return sprints;
        }

    }
}

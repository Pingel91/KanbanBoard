using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class Test
    {
        public int Id { get; set; }
        public static int nextId = 0;
        public string Name { get; set; }
        public string Description { get; set; }
        public string Steps { get; set; }
        public string Data { get; set; }
        public string ExpectedResult { get; set; }
        public string ActualResult { get; set; }
        public bool Passed { get; set; }

        public Test()
        {
            Id = nextId++;
        }
    }
}

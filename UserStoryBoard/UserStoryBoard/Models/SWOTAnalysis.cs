using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class SWOTAnalysis
    {
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public string Opportunity { get; set; }
        public string Threats { get; set; }

        public SWOTAnalysis()
        {

        }

        public SWOTAnalysis(string strengths, string weaknesses, string opportunity, string threats)
        {
            Strengths = strengths;
            Weaknesses = weaknesses;
            Opportunity = opportunity;
            Threats = threats;
        }
    }
}

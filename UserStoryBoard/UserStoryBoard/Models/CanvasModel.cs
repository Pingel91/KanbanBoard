using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class CanvasModel
    {
        public string KeyPartners { get; set; }
        public string KeyActivities { get; set; }
        public string KeyResources { get; set; }
        public string ValueProposition { get; set; }
        public string CustomerRelationship { get; set; }
        public string Channels { get; set; }
        public string CustomerSegment { get; set; }
        public string CostStructure { get; set; }
        public string RevenueStreams { get; set; }

        public CanvasModel()
        {

        }

        public CanvasModel(string keyPartners, string keyActivities, string keyResources, string valueProposition, string customerRelationship, string channels, string customerSegment, string costStructure, string revenueStreams)
        {
            KeyPartners = keyPartners;
            KeyActivities = keyActivities;
            KeyResources = keyResources;
            ValueProposition = valueProposition;
            CustomerRelationship = customerRelationship;
            Channels = channels;
            CustomerSegment = customerSegment;
            CostStructure = costStructure;
            RevenueStreams = revenueStreams;
        }
    }
}

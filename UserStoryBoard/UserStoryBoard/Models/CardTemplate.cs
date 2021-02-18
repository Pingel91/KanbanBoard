using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class CardTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        private static int nextId = 0;

        public CardTemplate()
        {

        }

        public CardTemplate (string name)
        {
            Id = nextId++;
            CreationDate = DateTime.Now;

            Name = name;
        }
    }
}

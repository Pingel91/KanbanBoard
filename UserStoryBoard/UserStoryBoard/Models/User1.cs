using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class User1
    {
        public int  Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Name cant be longer then 20 Chars")]
        public string Name { get; set; }

        public string ImageName { get; set; }

        private static int UserId = 0;

        public User1()
        {
            Id = UserId++;
        }

        public User1( string name, string imageName)
        {
            Id = UserId++;
            Name = name;
            ImageName = imageName;
        }
    }
}

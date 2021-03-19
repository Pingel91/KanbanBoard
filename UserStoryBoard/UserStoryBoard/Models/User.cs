using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserStoryBoard.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        private static int nextId = 0;

        public User()
        {
            
        }

        public User(string userName, string password)
        {
            Id = nextId++;
            UserName = userName;
            Password = password;
        }
    }
}

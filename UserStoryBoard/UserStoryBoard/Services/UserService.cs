using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.MockData;
using UserStoryBoard.Models;

namespace UserStoryBoard.Services
{
    public class UserService
    {
        private List<User1> userStories;

        public UserService()
        {
            userStories = MockUser.GetMockUsers();
        }
        public List<User1> GetUsers()
        {
            return userStories;
        }
    }
}

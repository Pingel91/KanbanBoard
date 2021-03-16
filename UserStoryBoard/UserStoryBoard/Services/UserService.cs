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
        private List<User> users;

        public UserService()
        {
            users = MockUsers.GetMockBoards();
        }
    }
}

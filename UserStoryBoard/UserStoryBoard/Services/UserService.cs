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
        private List<User1> users;

        public UserService()
        {
            users = MockUser.GetMockUsers();
        }
        public List<User1> GetUsers()
        {
            return users;
        }
        public void AddUser(User1 aUser)
        {
            users.Add(aUser);
            // JsonFileUserStoryService.SaveJsonUserStories(kanbanBoards);
        }
    }
}

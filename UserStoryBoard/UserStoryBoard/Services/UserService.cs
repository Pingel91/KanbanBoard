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

        public User1 GetUser (int id)
        {
            User1 TheUser = null;
            foreach (User1 user in users)
            {
                if (user.Id == id)
                {
                    TheUser = user;
                }
            }

            return TheUser;
        }
        public void DeleteUser(int UserId)
        {
            User1 userToBeDeleted = null;
            foreach (User1 user in users)
            {
                if (user.Id == UserId)
                {
                    userToBeDeleted = user;
                    break;
                }
            }
            if (userToBeDeleted != null)
            {
                users.Remove(userToBeDeleted);

            }
        }
        public void UpdateUser(User1 user)
        {
            if (user != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].Id == user.Id)
                    {
                        users[i] = user;
                    }
                }

                //JsonFileUserStoryService.SaveJsonUserStories(kanbanBoards);
            }
        }
    }
}

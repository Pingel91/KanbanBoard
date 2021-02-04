using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.MockData;
using UserStoryBoard.Models;

namespace UserStoryBoard.Services
{
    public class UserStoryService
    {
        public enum ColumnType { Todo, Doing, Done }

        private List<UserStory> userStories;

        public UserStoryService()
        {
            userStories = MockUserStories.GetMockUserStories();
        }

        public List<UserStory> GetUserStories()
        {
            return userStories; 
        }

        public UserStory GetUserStory(int id)
        {
            foreach (UserStory userStory in userStories)
            {
                if (userStory.Id == id)
                    return userStory;
            }

            return null;
        }

        public UserStory DeleteUserStory(int userStoryId)
        {
            UserStory userStoryToBeDeleted = null;
            foreach (UserStory us in userStories)
            {
                if (us.Id == userStoryId)
                {
                    userStoryToBeDeleted = us;
                    break;
                }
            }
            if (userStoryToBeDeleted !=null)
            {
                userStories.Remove(userStoryToBeDeleted);
            }
            return userStoryToBeDeleted;
        }

        public void AddUserStory(UserStory aUserStory)
        {
            userStories.Add(aUserStory);
        }
    }
}

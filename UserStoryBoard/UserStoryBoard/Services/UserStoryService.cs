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
        private List<UserStory> userStories;
        private JsonFileUserStoryService JsonFileUserStoryService { get; set; }

        public UserStoryService(JsonFileUserStoryService jsonFileUserStoryService)
        {
            JsonFileUserStoryService = jsonFileUserStoryService;
            userStories = JsonFileUserStoryService.GetJsonUserStory().ToList();
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

        public UserStory GetUserStoryByColumn(int column)
        {
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
                JsonFileUserStoryService.SaveJsonUserStories(userStories);
            }
            return userStoryToBeDeleted;
        }

        public void UpdateUserStory(UserStory userStory)
        {
            if (userStory != null)
            {

                for (int i = 0; i < userStories.Count; i++)
                {
                    if (userStories[i].Id == userStory.Id)
                    {
                        userStories[i] = userStory;
                    }
                }
                JsonFileUserStoryService.SaveJsonUserStories(userStories);
            }
        }

        public void AddUserStory(UserStory aUserStory)
        {
            userStories.Add(aUserStory);
            JsonFileUserStoryService.SaveJsonUserStories(userStories);

        }
    }
}

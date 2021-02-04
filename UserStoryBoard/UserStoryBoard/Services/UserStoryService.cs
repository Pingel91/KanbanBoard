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



        public void UpdateUserStory(UserStory userStory)
        {
            if (userStory != null)
            {

                for (int i = 0; i < userStories.Count; i++)
                {
                    if (userStories[i].Id == userStory.Id)
                    {
                        userStories[i] = userStory;
                        break;
                    }
                }
                //foreach (UserStory u in userStories)
                //{
                //    if (u.Id == userStory.Id)
                //    {
                //        userStori
                //        //u.Title = userStory.Title;
                //        //u.Description = userStory.Description;
                //        //u.BusinessValue = userStory.BusinessValue;
                //        //u.CreationDate = userStory.CreationDate;
                //        //u.Priority = userStory.Priority;
                //        //u.StoryPoints = userStory.StoryPoints;
                //    }
                //}


            }
        }
        public void AddUserStory(UserStory aUserStory)
        {
            userStories.Add(aUserStory);

        }
    }
}

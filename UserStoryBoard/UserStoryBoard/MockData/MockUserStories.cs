﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;

namespace UserStoryBoard.MockData
{
    public class MockUserStories
    {
        private static List<UserStory> userStories = new List<UserStory>()
        {
            new UserStory
            (
                "Create Story", 
                "As P.O I want to create a new story So...", 
                1,  
                4, 
                "Small", 
                0
            ),
            new UserStory
            (
                "Edit Story", 
                "As P.O I want to edit a Story So...", 
                2,  
                2, 
                "Medium", 
                0
            ),
            new UserStory
            (
                "Move Story", 
                "As a team member I want to move a Story So...", 
                1, 
                3, 
                "Large", 
                1
            ),
            new UserStory
            (
                "Delete Story", 
                "As a team member I want to delete a Story So...", 
                3,  
                1, 
                "Large", 
                1
            ),
            new UserStory
            (
                "Column DONE Story test", 
                "As A programmer I want to move stories so...", 
                3,  
                1, 
                "Large", 
                1, 
                2
            )
        };

        public static List<UserStory> GetMockUserStories()
        {
            return userStories;
        }
    }
}

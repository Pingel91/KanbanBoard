using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;

namespace UserStoryBoard.MockData
{
    public class MockUser
    {
        public static List<User1> Users = new List<User1>()
        {
            new User1("YeaBoi","Cheese_pizza.jfif"),
            new User1("YeaBois","Cheese_pizza.jfif"),
            new User1("YeaBoiss","Cheese_pizza.jfif")
        };


        public static List<User1> GetMockUsers()
        {
            return Users;
        }
    }
}

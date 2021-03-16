using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;

namespace UserStoryBoard.MockData
{
    public class MockUsers
    {
        public static List<User> Users = new List<User>()
        {
            new User("Cesper123", "SupermanLover123"),
            new User("Putrick", "ElskerCesper"),
            new User("saibot", "Tobias")
        };


        public static List<User> GetMockUsers()
        {
            return Users;
        }
    }
}

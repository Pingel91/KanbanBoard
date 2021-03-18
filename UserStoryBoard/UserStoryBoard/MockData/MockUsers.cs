using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using UserStoryBoard.Models;

namespace UserStoryBoard.MockData
{
    public class MockUsers
    {
        private static PasswordHasher<string> passwordHasher = new PasswordHasher<string>(); 

        public static List<User> Users = new List<User>()
        {
            new User("Cesper123", passwordHasher.HashPassword(null,"SupermanLover123")),
            new User("Putrick", passwordHasher.HashPassword(null,"ElskerCesper")),
            new User("saibot",  passwordHasher.HashPassword(null,"tobias")),
            new User("admin",  passwordHasher.HashPassword(null,"secret"))
        };


        public static List<User> GetMockUsers()
        {
            return Users;
        }
    }
}

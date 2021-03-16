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
        private List<User> Users = new List<User>();
        private JsonFileService<User> JsonFileService { get; set; }

        public UserService(JsonFileService<User> jsonFileUserService)
        {
            JsonFileService = jsonFileUserService;

            // Use this if it's the first time the program is started or there is no Json file yet.
            //Users = MockUsers.GetMockUsers();
            //JsonFileService.SaveJsonObjects(Users);

            // Use this if you want to read from the existing Json file.
            Users = JsonFileService.GetJsonObjects().ToList();
        }

        public List<User> GetUsers()
        {
            return Users;
        }
    }
}

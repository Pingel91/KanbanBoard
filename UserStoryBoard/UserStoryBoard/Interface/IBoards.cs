using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;

namespace UserStoryBoard.Interface
{
    public interface IBoards
    {


        public List<UserStory> GetUserStories(int boardId);
        
        public Board GetBoard(int id);


        public UserStory GetUserStory(int id, int boardId);

        public void AddBoard(Board board);

        public void AddUserStory(UserStory aUserStory, int boardId);


        public void UpdateBoard(Board board);
        

        public void UpdateUserStory(UserStory userStory, int boardId);
       

        public void DeleteBoardId(int boardId);
      

        public UserStory DeleteUserStory(int userStoryId, int boardId);
        
       
        
    }
}

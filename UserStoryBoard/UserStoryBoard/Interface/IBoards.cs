using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;

namespace UserStoryBoard.Interface
{
    public interface IBoards
    {
        // GET ALL
        public List<Board> GetAllBoards();
       
        // GET LISTS
        public List<UserStory> GetUserStories(int boardId);

        public List<UserStory> GetUserStoriesInBacklog(int boardId);
        
        // GET SINGLE ITEM
        public Board GetBoard(int id);

        public UserStory GetUserStory(int id, int boardId, bool backlog);

        // ADD
        public void AddBoard(Board board);

        public void AddUserStory(UserStory aUserStory, int boardId, bool backlog);

        // UPDATE
        public void UpdateBoard(Board board);

        public void UpdateUserStory(UserStory userStory, int boardId, bool backlog);

        // DELETE
        public void DeleteBoardId(int boardId);
      
        public UserStory DeleteUserStory(int userStoryId, int boardId, bool backlog);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.MockData;
using UserStoryBoard.Models;

namespace UserStoryBoard.Services
{
    public class BoardService
    {
        // PROPERTIES --------------------------------------------------------------------
        private List<Board> kanbanBoards;
        //private List<UserStory> userStories;

        // CONSTRUCTOR -------------------------------------------------------------------
        public BoardService()
        {
            kanbanBoards = MockKanbanBoards.GetMockBoards();
            //userStories = MockUserStories.GetMockUserStories();

            // TEMPORARILY SETTING USER STORIES ON A BOARD TO MOCK DATA 
            foreach (UserStory uS in MockUserStories.GetMockUserStories())
            {
                kanbanBoards[uS.BoardId].userStoriesOnBoard.Add(uS);
            }
        }

        // GET LISTS ---------------------------------------------------------------------
        public List<Board> GetAllBoards()
        {
            return kanbanBoards;
        }

        public List<UserStory> GetUserStories(int boardId)
        {
            return kanbanBoards[boardId].userStoriesOnBoard;
        }

        // GET SPECIFIC OBJECT -----------------------------------------------------------
        public Board GetBoard(int id)
        {
            foreach (Board b in kanbanBoards)
            {
                if (b.Id == id)
                    return b;
            }

            return null;
        }

        public UserStory GetUserStory(int id, int boardId)
        {
            foreach (UserStory userStory in kanbanBoards[boardId].userStoriesOnBoard)
            {
                if (userStory.Id == id)
                    return userStory;
            }

            return null;
        }

        // ADD ---------------------------------------------------------------------------
        public void AddBoard(Board aBoard)
        {
            kanbanBoards.Add(aBoard);
            // JsonFileUserStoryService.SaveJsonUserStories(kanbanBoards);
        }

        public void AddUserStory(UserStory aUserStory, int boardId)
        {
            kanbanBoards[boardId].userStoriesOnBoard.Add(aUserStory);
            //JsonFileUserStoryService.SaveJsonUserStories(userStories);
        }

        // UPDATE ------------------------------------------------------------------------
        public void UpdateBoard(Board board)
        {
            if (board != null)
            {
                for (int i = 0; i < kanbanBoards.Count; i++)
                {
                    if (kanbanBoards[i].Id == board.Id)
                    {
                        kanbanBoards[i] = board;
                    }
                }

                //JsonFileUserStoryService.SaveJsonUserStories(kanbanBoards);
            }
        }


        public void UpdateUserStory(UserStory userStory, int boardId)
        {
            if (userStory != null)
            {

                for (int i = 0; i < kanbanBoards[boardId].userStoriesOnBoard.Count; i++)
                {
                    if (kanbanBoards[boardId].userStoriesOnBoard[i].Id == userStory.Id)
                    {
                        kanbanBoards[boardId].userStoriesOnBoard[i] = userStory;
                    }
                }
                //JsonFileUserStoryService.SaveJsonUserStories(userStories);
            }
        }

        // DELETE ------------------------------------------------------------------------

        public void DeleteBoardId(int boardId)
        {
            Board boardtoBeDeleted = null;
            foreach (Board board in kanbanBoards)
            {
                if (board.Id == boardId)
                {
                    boardtoBeDeleted = board;
                    break;
                }
            }
            if (boardtoBeDeleted != null)
            {
                kanbanBoards.Remove(boardtoBeDeleted);
                
            }
        }

        public UserStory DeleteUserStory(int userStoryId, int boardId)
        {
            UserStory userStoryToBeDeleted = null;
            foreach (UserStory us in kanbanBoards[boardId].userStoriesOnBoard)
            {
                if (us.Id == userStoryId)
                {
                    userStoryToBeDeleted = us;
                    break;
                }
            }
            if (userStoryToBeDeleted != null)
            {
                kanbanBoards[boardId].userStoriesOnBoard.Remove(userStoryToBeDeleted);
                //JsonFileUserStoryService.SaveJsonUserStories(userStories);
            }
            return userStoryToBeDeleted;
        }
    }
}

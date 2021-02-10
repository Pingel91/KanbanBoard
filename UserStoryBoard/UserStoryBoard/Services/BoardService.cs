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
            foreach (Board b in kanbanBoards)
            {
                if (b.Id == boardId)
                    return b.userStoriesOnBoard;
            }

            return null;
        }

        // GET SPECIFIC OBJECT -----------------------------------------------------------
        public Board GetBoard(int id)
        {
            Board theBoard = null;
            foreach (Board b in kanbanBoards)
            {
                if (b.Id == id)
                {
                    theBoard = b;
                }
            }

            return theBoard;
        }

        public UserStory GetUserStory(int id, int boardId)
        {
            foreach (Board board in kanbanBoards)
            {
                if (board.Id == boardId)
                {
                    for (int i = 0; i < board.userStoriesOnBoard.Count; i++)
                    {
                        if (board.userStoriesOnBoard[i].Id == id)
                            return board.userStoriesOnBoard[i];
                    }
                    break;
                }
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
                foreach (Board board in kanbanBoards)
                {
                    if (board.Id == boardId)
                    {
                        for (int i = 0; i < board.userStoriesOnBoard.Count; i++)
                        {
                            if (board.userStoriesOnBoard[i].Id == userStory.Id)
                                board.userStoriesOnBoard[i] = userStory;
                        }
                        break;
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

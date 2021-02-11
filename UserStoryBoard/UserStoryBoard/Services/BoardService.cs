using System;
using System.Diagnostics;
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
        private int totalMockUserStories = 0;

        // CONSTRUCTOR -------------------------------------------------------------------
        public BoardService()
        {
            kanbanBoards = MockKanbanBoards.GetMockBoards();
            //userStories = MockUserStories.GetMockUserStories();

            // TEMPORARILY SETTING USER STORIES ON A BOARD TO MOCK DATA 
            foreach (UserStory uS in MockUserStories.GetMockUserStories())
            {
                for (int i = 0; i < kanbanBoards.Count; i++)
                {
                    if (kanbanBoards[i].Id == uS.BoardId)
                    {
                        kanbanBoards[i].userStoriesOnBoard.Add(uS);
                        totalMockUserStories++;
                        Debug.WriteLine($"\n------Added User Story: {uS.Title}\n ID: {uS.Id}\n - On board: {uS.BoardId}\n");
                    }
                }
            }
            Debug.WriteLine($"Total Mock User Stories: {totalMockUserStories}");
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
            Board b = null;
            foreach (Board board in kanbanBoards)
            {
                if (board.Id == boardId)
                {
                    board.userStoriesOnBoard.Add(aUserStory);
                    b = board;
                    Debug.WriteLine($"ADDED USER STORY '{aUserStory.Title}' TO BOARD '{board.BoardName}'");
                    Debug.WriteLine($"USER STORY IS ON COLUMN '{aUserStory.ColumnId}'");
                }
            }
            if (b != null)
            {
                Debug.WriteLine($"UPDATED BOARD '{b.BoardName}'");
                Debug.WriteLine($"USER STORIES ON THE BOARD:");
                foreach (UserStory uS in b.userStoriesOnBoard)
                {
                    Debug.WriteLine($"{aUserStory.Title}");
                }
                UpdateBoard(b);
            }
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
                        Debug.WriteLine($"\n------Updating User Story: {userStory.Title}\n Entered board: {boardId}\n");
                        for (int i = 0; i < board.userStoriesOnBoard.Count; i++)
                        {
                            if (board.userStoriesOnBoard[i].Id == userStory.Id)
                            {
                                Debug.WriteLine($"\n------User Story ID: {userStory.Id}\n");
                                board.userStoriesOnBoard[i] = userStory;
                                Debug.WriteLine($"\n------Updated User Story: {userStory.Title}\n ID: {userStory.Id}\n - On board: {userStory.BoardId}\n");
                                break;
                            }
                        }
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

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.MockData;
using UserStoryBoard.Models;
using UserStoryBoard.Interface;

namespace UserStoryBoard.Services
{
    public class BoardService : IBoards
    {
        // PROPERTIES --------------------------------------------------------------------
        //private List<UserStory> userStories;
        //private int totalMockUserStories = 0;
        private JsonFileBoards boardJsonService;

        // CONSTRUCTOR -------------------------------------------------------------------
        public BoardService(JsonFileBoards bJsonService)
        {
            boardJsonService = bJsonService;
            //userStories = MockUserStories.GetMockUserStories();

            // RUN THIS ONCE
            //boardJsonService.SaveJsonBoards(MockKanbanBoards.kanbanBoards);

            // TEMPORARILY SETTING USER STORIES ON A BOARD TO MOCK DATA 
            //foreach (UserStory uS in MockUserStories.GetMockUserStories())
            //{
            //    for (int i = 0; i < kanbanBoards.Count; i++)
            //    {
            //        if (kanbanBoards[i].Id == uS.BoardId)
            //        {
            //            kanbanBoards[i].userStoriesOnBoard.Add(uS);
            //            totalMockUserStories++;
            //            Debug.WriteLine($"\n------Added User Story: {uS.Title}\n ID: {uS.Id}\n - On board: {uS.BoardId}\n");
            //        }
            //    }
            //}
            //Debug.WriteLine($"Total Mock User Stories: {totalMockUserStories}");
        }

        // GET LISTS ---------------------------------------------------------------------
        public List<Board> GetAllBoards()
        {
            return boardJsonService.GetJsonBoards().ToList();
        }

        public List<UserStory> GetUserStories(int boardId)
        {
            foreach (Board b in boardJsonService.GetJsonBoards())
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
            foreach (Board b in boardJsonService.GetJsonBoards())
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
            foreach (Board board in boardJsonService.GetJsonBoards())
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
        public void AddBoard(Board board)
        {
            List<Board> newBoards = boardJsonService.GetJsonBoards().ToList();
            newBoards.Add(board);
            boardJsonService.SaveJsonBoards(newBoards);
        }

        public void AddUserStory(UserStory aUserStory, int boardId)
        {
            Board b = null;
            List<Board> newBoards = boardJsonService.GetJsonBoards().ToList();

            foreach (Board board in newBoards)
            {
                if (board.Id == boardId)
                {
                    board.userStoriesOnBoard.Add(aUserStory);
                    b = board;

                    boardJsonService.SaveJsonBoards(newBoards);

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
                List<Board> newBoards = boardJsonService.GetJsonBoards().ToList();

                for (int i = 0; i < boardJsonService.GetJsonBoards().ToList().Count; i++)
                {
                    if (boardJsonService.GetJsonBoards().ToList()[i].Id == board.Id)
                    {
                        newBoards[i] = board;
                        boardJsonService.SaveJsonBoards(newBoards);
                    }
                }

                //JsonFileUserStoryService.SaveJsonUserStories(kanbanBoards);
            }
        }


        public void UpdateUserStory(UserStory userStory, int boardId)
        {
            if (userStory != null)
            {
                foreach (Board board in boardJsonService.GetJsonBoards())
                {
                    if (board.Id == boardId)
                    {
                        Debug.WriteLine($"\n------Updating User Story: {userStory.Title}\n Entered board: {boardId}\n");
                        for (int i = 0; i < board.userStoriesOnBoard.Count; i++)
                        {
                            if (board.userStoriesOnBoard[i].Id == userStory.Id)
                            {
                                board.userStoriesOnBoard[i] = userStory;

                                UpdateBoard(board);

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
            List<Board> newBoards = boardJsonService.GetJsonBoards().ToList();

            // Find the board to delete
            foreach (Board board in newBoards)
            {
                if (board.Id == boardId)
                {
                    // Remove it from the temporary list of boards, and save that to JSON
                    newBoards.Remove(board);
                    boardJsonService.SaveJsonBoards(newBoards);
                    break;
                }
            }

        }

        public UserStory DeleteUserStory(int userStoryId, int boardId)
        {
            UserStory userStoryToBeDeleted = null;
            List<Board> newBoards = boardJsonService.GetJsonBoards().ToList();

            // Find the User Story to be deleted
            foreach (UserStory us in newBoards[boardId].userStoriesOnBoard)
            {
                if (us.Id == userStoryId)
                {
                    userStoryToBeDeleted = us;
                    break;
                }
            }

            // Remove it from the temporary list of boards, and save that to JSON
            if (userStoryToBeDeleted != null)
            {
                newBoards[boardId].userStoriesOnBoard.Remove(userStoryToBeDeleted);
                boardJsonService.SaveJsonBoards(newBoards);
            }

            return userStoryToBeDeleted;
        }
    }
}

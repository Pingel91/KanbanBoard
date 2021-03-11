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
        private JsonFileBoards boardJsonService;

        // CONSTRUCTOR -------------------------------------------------------------------
        public BoardService(JsonFileBoards bJsonService)
        {
            boardJsonService = bJsonService;

            // RUN THIS ONCE TO SET UP MOCK DATA
            //boardJsonService.SaveJsonBoards(MockKanbanBoards.kanbanBoards);
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
                    return b.UserStoriesOnBoard;
            }

            return null;
        }
        public List<UserStory> GetUserStoriesInBacklog(int boardId)
        {
            foreach (Board b in boardJsonService.GetJsonBoards())
            {
                if (b.Id == boardId)
                    return b.BoardBacklog.UserStoriesInBacklog;
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

        public UserStory GetUserStory(int id, int boardId, bool backlog)
        {
            foreach (Board board in boardJsonService.GetJsonBoards())
            {
                if (board.Id == boardId)
                {
                    // Check if we are in the backlog, or the main board.
                    if (!backlog)
                    {
                        // If we're in the main board, return the mathcing user story from the list directly on the board object.
                        for (int i = 0; i < board.UserStoriesOnBoard.Count; i++)
                        {
                            if (board.UserStoriesOnBoard[i].Id == id)
                                return board.UserStoriesOnBoard[i];
                        }
                    }
                    else
                    {
                        // If we're in the backlog, go through the board and its attached backlog, and return the user story list on that.
                        for (int i = 0; i < board.BoardBacklog.UserStoriesInBacklog.Count; i++)
                        {
                            if (board.BoardBacklog.UserStoriesInBacklog[i].Id == id)
                                return board.BoardBacklog.UserStoriesInBacklog[i];
                        }
                    }
                    break;
                }
            }

            return null;
        }

        public Backlog GetBacklog(int boardId)
        {
            Backlog theBacklog = null;
            foreach (Board b in boardJsonService.GetJsonBoards())
            {
                if (b.Id == boardId)
                {
                    theBacklog = b.BoardBacklog;
                }
                
            }

            return theBacklog;
        }
        

        // ADD ---------------------------------------------------------------------------
        public void AddBoard(Board board)
        {
            List<Board> newBoards = boardJsonService.GetJsonBoards().ToList();
            newBoards.Add(board);
            boardJsonService.SaveJsonBoards(newBoards);
        }

        public void AddUserStory(UserStory aUserStory, int boardId, bool backlog)
        {
            Board b = null;
            List<Board> newBoards = boardJsonService.GetJsonBoards().ToList();

            foreach (Board board in newBoards)
            {
                if (board.Id == boardId)
                {
                    // Add to backlog if we came from the Backlog page
                    if (backlog)
                        board.BoardBacklog.UserStoriesInBacklog.Add(aUserStory);
                    else
                        board.UserStoriesOnBoard.Add(aUserStory);

                    b = board;

                    boardJsonService.SaveJsonBoards(newBoards);

                    Debug.WriteLine($"ADDED USER STORY '{aUserStory.Name}' TO BOARD '{board.Name}'");
                    Debug.WriteLine($"USER STORY IS ON COLUMN '{aUserStory.ColumnId}'");
                }
            }
            if (b != null)
            {
                Debug.WriteLine($"UPDATED BOARD '{b.Name}'");
                Debug.WriteLine($"USER STORIES ON THE BOARD:");
                foreach (UserStory uS in b.UserStoriesOnBoard)
                {
                    Debug.WriteLine($"{aUserStory.Name}");
                }
                UpdateBoard(b);
            }
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
            }
        }


        public void UpdateUserStory(UserStory userStory, int boardId, bool backlog)
        {
            if (userStory != null)
            {
                foreach (Board board in boardJsonService.GetJsonBoards())
                {
                    if (board.Id == boardId)
                    {
                        Debug.WriteLine($"\n------Updating User Story: {userStory.Name}\n Entered board: {boardId}\n");

                        if (!backlog)
                        {
                            for (int i = 0; i < board.UserStoriesOnBoard.Count; i++)
                            {
                                if (board.UserStoriesOnBoard[i].Id == userStory.Id)
                                {
                                    board.UserStoriesOnBoard[i] = userStory;

                                    UpdateBoard(board);

                                    Debug.WriteLine($"\n------Updated User Story: {userStory.Name}\n ID: {userStory.Id}\n - On board: {userStory.BoardId}\n");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int i = 0; i < board.BoardBacklog.UserStoriesInBacklog.Count; i++)
                            {
                                if (board.BoardBacklog.UserStoriesInBacklog[i].Id == userStory.Id)
                                {
                                    board.BoardBacklog.UserStoriesInBacklog[i] = userStory;

                                    UpdateBoard(board);

                                    Debug.WriteLine($"\n------Updated User Story: {userStory.Name}\n ID: {userStory.Id}\n - On board: {userStory.BoardId}\n - In backlog?: {backlog}");
                                    break;
                                }
                            }
                        }
                    }
                }
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

        public UserStory DeleteUserStory(int userStoryId, int boardId, bool backlog)
        {
            UserStory userStoryToBeDeleted = null;
            List<Board> newBoards = boardJsonService.GetJsonBoards().ToList();

            // This is just a quick way of writing an if-statement. 
            /// Instead of writing the whole if/else thing, this question-mark operator 
            /// just checks if the "backlog" is true or false, and sets the list to be the one or the other.
            List<UserStory> userStoriesList = backlog ? newBoards[boardId].BoardBacklog.UserStoriesInBacklog : newBoards[boardId].UserStoriesOnBoard;

            // Find the User Story to be deleted
            foreach (UserStory us in userStoriesList)
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
                userStoriesList.Remove(userStoryToBeDeleted);
                boardJsonService.SaveJsonBoards(newBoards);
            }

            return userStoryToBeDeleted;
        }
    }
}

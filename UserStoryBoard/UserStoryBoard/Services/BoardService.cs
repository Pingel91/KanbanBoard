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
        // PROPERTIES ------------------------------------------------------------------------------------------------------------------------------ PROPERTIES
        private JsonFileService<Board> boardJsonService;
        private int nextCardId;
        private int nextBoardId;
        // WE NEED TO IMPLEMENT THIS AND SAVE WHAT CURRENT ID WE HAVE GOTTEN TO IN THE JSON. OTHERWISE WHEN YOU RESTART THE PROGRAM THE nextId will be 0!!!!!

        // CONSTRUCTOR ----------------------------------------------------------------------------------------------------------------------------- CONSTRUCTOR
        public BoardService(JsonFileService<Board> bJsonService)
        {
            boardJsonService = bJsonService;

            // RUN THIS ONCE TO SET UP MOCK DATA
            //boardJsonService.SaveJsonObjects(MockKanbanBoards.kanbanBoards);
        }

        // GET LISTS ------------------------------------------------------------------------------------------------------------------------------- GET LISTS
        public List<Board> GetAllBoards()
        {
            return boardJsonService.GetJsonObjects().ToList();
        }

        public List<UserStory> GetUserStories(int boardId)
        {
            foreach (Board b in boardJsonService.GetJsonObjects())
            {
                if (b.Id == boardId)
                    return b.UserStoriesOnBoard;
            }

            return null;
        }
        public List<UserStory> GetUserStoriesInBacklog(int boardId)
        {
            foreach (Board b in boardJsonService.GetJsonObjects())
            {
                if (b.Id == boardId)
                    return b.BoardBacklog.UserStoriesInBacklog;
            }

            return null;
        }

        // GET SPECIFIC OBJECT --------------------------------------------------------------------------------------------------------------------- GET SPECIFIC OBJECT
        public Board GetBoard(int id)
        {
            Board theBoard = null;
            foreach (Board b in boardJsonService.GetJsonObjects())
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
            foreach (Board board in boardJsonService.GetJsonObjects())
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
            foreach (Board b in boardJsonService.GetJsonObjects())
            {
                if (b.Id == boardId)
                {
                    theBacklog = b.BoardBacklog;
                }
                
            }

            return theBacklog;
        }


        // ADD ------------------------------------------------------------------------------------------------------------------------------------- ADD
        public void AddBoard(Board board)
        {
            List<Board> newBoards = boardJsonService.GetJsonObjects().ToList();
            newBoards.Add(board);
            boardJsonService.SaveJsonObjects(newBoards);
        }

        public void AddUserStory(UserStory userStory, int boardId, bool backlog)
        {
            Board b = null;
            List<Board> newBoards = boardJsonService.GetJsonObjects().ToList();

            foreach (Board board in newBoards)
            {
                if (board.Id == boardId)
                {
                    // Add to backlog if we came from the Backlog page
                    if (backlog)
                        board.BoardBacklog.UserStoriesInBacklog.Add(userStory);
                    else
                        board.UserStoriesOnBoard.Add(userStory);

                    b = board;

                    boardJsonService.SaveJsonObjects(newBoards);

                    Debug.WriteLine($"ADDED USER STORY '{userStory.Name}' TO BOARD '{board.Name}'");
                    Debug.WriteLine($"USER STORY IS ON COLUMN '{userStory.ColumnId}'");
                }
            }
            if (b != null)
            {
                Debug.WriteLine($"UPDATED BOARD '{b.Name}'");
                Debug.WriteLine($"USER STORIES ON THE BOARD:");
                foreach (UserStory uS in b.UserStoriesOnBoard)
                {
                    Debug.WriteLine($"{userStory.Name}");
                }
                UpdateBoard(b);
            }
        }

        // UPDATE ---------------------------------------------------------------------------------------------------------------------------------- UPDATE
        public void UpdateBoard(Board board)
        {
            if (board != null)
            {
                List<Board> newBoards = boardJsonService.GetJsonObjects().ToList();

                for (int i = 0; i < boardJsonService.GetJsonObjects().ToList().Count; i++)
                {
                    if (boardJsonService.GetJsonObjects().ToList()[i].Id == board.Id)
                    {
                        newBoards[i] = board;
                        boardJsonService.SaveJsonObjects(newBoards);
                    }
                }
            }
        }


        public void UpdateUserStory(UserStory userStory, int boardId, bool backlog)
        {
            if (userStory != null)
            {
                foreach (Board board in boardJsonService.GetJsonObjects())
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
                                    // Set column ID to the importance level - ONLY BECAUSE THIS IS IN THE BACKLOG
                                    if (userStory.Priority >= 0 && userStory.Priority < 4)
                                        userStory.ColumnId = userStory.Priority;
                                    else userStory.ColumnId = 0;

                                    // Update the user story in the list
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

        // DELETE ---------------------------------------------------------------------------------------------------------------------------------- DELETE

        public void DeleteBoardId(int boardId)
        {
            List<Board> newBoards = boardJsonService.GetJsonObjects().ToList();

            // Find the board to delete
            foreach (Board board in newBoards)
            {
                if (board.Id == boardId)
                {
                    // Remove it from the temporary list of boards, and save that to JSON
                    newBoards.Remove(board);
                    boardJsonService.SaveJsonObjects(newBoards);
                    break;
                }
            }

        }

        public UserStory DeleteUserStory(int userStoryId, int boardId, bool backlog)
        {
            UserStory userStoryToBeDeleted = null;
            List<Board> newBoards = boardJsonService.GetJsonObjects().ToList();

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
                boardJsonService.SaveJsonObjects(newBoards);
            }

            return userStoryToBeDeleted;
        }

        // MOVE TO/FROM BACKLOG -------------------------------------------------------------------------------------------------------------------- MOVE TO/FROM BACKLOG
        public void MoveToBacklog (UserStory userStory, int boardId)
        {
            if (userStory != null)
            {
                foreach (Board board in boardJsonService.GetJsonObjects())
                {
                    if (board.Id == boardId)
                    {
                        Debug.WriteLine($"\n------Moving User Story: {userStory.Name} to Backlog\n");

                        for (int i = 0; i < board.UserStoriesOnBoard.Count; i++)
                        {
                            if (board.UserStoriesOnBoard[i].Id == userStory.Id)
                            {
                                // Remove from the Main Board
                                board.UserStoriesOnBoard.RemoveAt(i);

                                // Set column ID to the importance level
                                if (userStory.Priority >= 0 && userStory.Priority < 4)
                                    userStory.ColumnId = userStory.Priority;
                                else userStory.ColumnId = 0;

                                // Add the user story to the Backlog
                                board.BoardBacklog.UserStoriesInBacklog.Add(userStory);

                                UpdateBoard(board);

                                Debug.WriteLine($"\n------Moved User Story: {userStory.Name} to Backlog\n ID: {userStory.Id}\n - On board: {userStory.BoardId}\n");
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void MoveToBoard(UserStory userStory, int boardId)
        {
            if (userStory != null)
            {
                foreach (Board board in boardJsonService.GetJsonObjects())
                {
                    if (board.Id == boardId)
                    {
                        Debug.WriteLine($"\n------Moving User Story: {userStory.Name} to Board\n");

                        for (int i = 0; i < board.BoardBacklog.UserStoriesInBacklog.Count; i++)
                        {
                            if (board.BoardBacklog.UserStoriesInBacklog[i].Id == userStory.Id)
                            {
                                // Remove from the Main Board
                                board.BoardBacklog.UserStoriesInBacklog.RemoveAt(i);

                                // Set column ID to 0
                                userStory.ColumnId = 0;

                                // Add the user story to the Backlog
                                board.UserStoriesOnBoard.Add(userStory);

                                UpdateBoard(board);

                                Debug.WriteLine($"\n------Moved User Story: {userStory.Name} to Board\n ID: {userStory.Id}\n - On board: {userStory.BoardId}\n");
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using UserStoryBoard.Helpers;
using UserStoryBoard.Models;

namespace UserStoryBoard.Services
{
    public class JsonFileBoards
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        public JsonFileBoards(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Board.json"); }
        }
        public List<Board> AllBoards()
        {
            try { return JsonHelper.ReadBoards(JsonFileName); }
            catch (ArgumentException aExc) { Console.WriteLine(aExc); return null; }
        }

        public List<UserStory> GetUserStories(int boardId)
        {
            foreach (Board b in AllBoards())
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
            foreach (Board b in AllBoards())
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
            foreach (Board board in AllBoards())
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
            AllBoards().Add(aBoard);
            // JsonFileUserStoryService.SaveJsonUserStories(kanbanBoards);
        }

        public void AddUserStory(UserStory aUserStory, int boardId)
        {
            AllBoards()[boardId].userStoriesOnBoard.Add(aUserStory);
            //JsonFileUserStoryService.SaveJsonUserStories(userStories);
        }

        // UPDATE ------------------------------------------------------------------------
        public void UpdateBoard(Board board)
        {
            if (board != null)
            {
                for (int i = 0; i < AllBoards().Count; i++)
                {
                    if (AllBoards()[i].Id == board.Id)
                    {
                        AllBoards()[i] = board;
                    }
                }

                //JsonFileUserStoryService.SaveJsonUserStories(kanbanBoards);
            }
        }


        public void UpdateUserStory(UserStory userStory, int boardId)
        {
            if (userStory != null)
            {
                foreach (Board board in AllBoards())
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
            foreach (Board board in AllBoards())
            {
                if (board.Id == boardId)
                {
                    boardtoBeDeleted = board;
                    break;
                }
            }
            if (boardtoBeDeleted != null)
            {
                AllBoards().Remove(boardtoBeDeleted);

            }
        }

        public UserStory DeleteUserStory(int userStoryId, int boardId)
        {
            UserStory userStoryToBeDeleted = null;
            foreach (UserStory us in AllBoards()[boardId].userStoriesOnBoard)
            {
                if (us.Id == userStoryId)
                {
                    userStoryToBeDeleted = us;
                    break;
                }
            }
            if (userStoryToBeDeleted != null)
            {
                AllBoards()[boardId].userStoriesOnBoard.Remove(userStoryToBeDeleted);
                //JsonFileUserStoryService.SaveJsonUserStories(userStories);
            }
            return userStoryToBeDeleted;
        }
    }
}


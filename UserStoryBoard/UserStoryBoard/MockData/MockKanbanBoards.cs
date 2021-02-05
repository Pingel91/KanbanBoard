using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserStoryBoard.Models;

namespace UserStoryBoard.MockData
{
    public class MockKanbanBoards
    {

        public static List<Board> kanbanBoards = new List<Board>()
        {
            new Board("Kanban Board 1", new List<string>{ "To Do", "Doing", "Done"}, 3),
            new Board("Caspars Test Board", new List<string>{ "To Do", "Doing", "Done"}, 3),
            new Board("Board", new List<string>{ "To Do", "Doing", "Done"}, 3)
        };


        public static List<Board> GetMockBoards()
        {
            return kanbanBoards;
        }
    }
}

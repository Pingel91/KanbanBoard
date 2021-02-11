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
            new Board("Kanban Board 1", 3, "Pretty simple Kanban Board 1"),
            new Board("Caspars Test Board", 3, "Caspars mega cool board"),
            new Board("Board", 3, "wot")
        };


        public static List<Board> GetMockBoards()
        {
            return kanbanBoards;
        }
    }
}

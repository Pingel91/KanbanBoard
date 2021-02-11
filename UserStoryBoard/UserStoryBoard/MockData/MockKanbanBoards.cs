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
            new Board("Kanban Board 1", "Pretty simple Kanban Board 1"),
            new Board("Caspars Test Board", "Caspars mega cool board"),
            new Board("Board", "wot")
        };


        public static List<Board> GetMockBoards()
        {
            return kanbanBoards;
        }
    }
}

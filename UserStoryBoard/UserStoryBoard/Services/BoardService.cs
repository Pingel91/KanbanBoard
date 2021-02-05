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
        private List<Board> kanbanBoards;

        public BoardService()
        {
            kanbanBoards = MockKanbanBoards.GetMockBoards();
        }

        public List<Board> GetBoards()
        {
            return kanbanBoards;
        }

        public void DeleteKanbanBoard(Board aBoard)
        {
            if (aBoard != null)
            {
                kanbanBoards.Remove(aBoard);
            }
        }

        public Board GetKanbanBoard(string name)
        {
            foreach (Board board in kanbanBoards)
            {
                if (board.BoardName == name)
                {
                    return board;
                }
            }

            return new Board();
        }
    }
}

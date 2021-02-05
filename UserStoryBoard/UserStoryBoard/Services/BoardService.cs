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

        public List<Board> GetAllBoards()
        {
            return kanbanBoards;
        }

        public Board GetBoard (int id)
        {
            foreach (Board b in kanbanBoards)
            {
                if (b.Id == id)
                    return b;
            }

            return null;
        }

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
    }
}

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

        public Board GetBoard(int id)
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

<<<<<<< HEAD
        public void DeleteBoard(Board aBoard)
        {
            if (aBoard != null)
            {
                kanbanBoards.Remove(aBoard);
            }
=======
<<<<<<< HEAD
        public void AddBoard(Board aBoard)
        {
            kanbanBoards.Add(aBoard);
            // JsonFileUserStoryService.SaveJsonUserStories(kanbanBoards);
=======
        public void DeleteBoard(Board board)
        {
            
>>>>>>> 7a772f1c05ac0459b42cc345e247424cce11c148
>>>>>>> 01410dcee543530ac1e9ca5acc97d2f85514fd73
        }
    }
}

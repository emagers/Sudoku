using System.Collections.Generic;
using System.Linq;

namespace SudokuLogic
{
    public class Board : List<List<(int, List<int>)>> 
    {
        public Board() { }

        public Board(List<List<int>> board)
        {
            for (int i = 0; i < board.Count; i++)
            {
                Add(board[i].Select(item => (item, new List<int>())).ToList());
            }
        }
    }
}

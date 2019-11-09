using System.Collections.Generic;
using System.Linq;
using SudokuLogic.Enums;

namespace SudokuLogic
{
    public class Board : List<List<(int, List<int>)>> 
    {
        private readonly Dictionary<Difficulty, int> moveCounts = new Dictionary<int, int>
        {
             { Difficulty.EASY, 0 },
             { Difficulty.MEDIUM, 0 },
             { Difficulty.HARD, 0 },
             { Difficulty.EXPERT, 0 }
        };

        public Board() { }

        public Board(List<List<int>> board)
        {
            for (int i = 0; i < board.Count; i++)
            {
                Add(board[i].Select(item => (item, new List<int>())).ToList());
            }
        }

        public void UpdatePossibilitiesAtPosition(int row, int column, List<int> available, Difficulty reductionDifficilty)
        {
            
        }
    }
}

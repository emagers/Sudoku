using System.Collections.Generic;
using System.Linq;
using SudokuLogic.Enums;

namespace SudokuLogic
{
    public class Board : List<List<BoardItem>> 
    {
        private static readonly int[] Numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        private readonly Dictionary<Difficulty, int> moveCounts = new Dictionary<Difficulty, int>
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
                Add(board[i].Select(item => new BoardItem { Value = item, Possibilities = item > 0 ? new List<int>() : Numbers.ToList() }).ToList());
            }
        }

        public void UpdatePossibilitiesAtPosition(int row, int column, List<int> available, Difficulty reductionDifficilty)
        {
            this[row][column].Possibilities.RemoveAll(x => !available.Contains(x));

            moveCounts[reductionDifficilty]++;
        }

        public Dictionary<Difficulty, int> GetDifficulties() => moveCounts;

        public void SetPositions()
        {
            for (int row = 0; row < this.Count; row++)
            {
                for (int column = 0; column < this[row].Count; column++)
                {
                    if (this[row][column].Value == 0 && this[row][column].Possibilities.Count == 1)
                    {
                        this[row][column] = new BoardItem
                        {
                            Value = this[row][column].Possibilities.First(),
                            Possibilities = new List<int>()
                        };
                    }
                }
            }
        }
    }
}

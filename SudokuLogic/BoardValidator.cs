using System.Collections.Generic;
using System.Linq;

namespace SudokuLogic
{
    public static class BoardValidator
    {
        private static readonly List<int> completeNumbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public static bool IsLineValid(List<int> line) => !line.Where(x => line.Count(y => y != 0 && y == x) > 1).Any();

        public static bool IsLineComplete(List<int> line) => line.Count(x => x == 0) == 0 && !completeNumbers.Except(line).Any();

        public static bool IsBoardValid(Board board) 
        {
            List<List<(int, List<int>)>> allLines = new List<List<(int, List<int>)>>();
            allLines.AddRange(board.GetColumns());
            allLines.AddRange(board.GetRows());
            allLines.AddRange(board.GetSquares());

            bool valid = true;

            for (int i = 0; i < allLines.Count && valid; i++)
            {
                if (!IsLineValid(allLines[i].Select(line => line.Item1).ToList()))
                {
                    valid = false;
                }
            }

            return valid;
        }

        public static bool IsBoardComplete(Board board) => IsBoardValid(board) && board.Sum(line => line.Count(x => x.Item1 == 0)) == 0;
    }
}

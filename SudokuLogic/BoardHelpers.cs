using System.Collections.Generic;
using System.Linq;

namespace SudokuLogic
{
    public static class BoardHelpers
    {
        public static List<List<int>> GetColumns(this Board board) => board.Select((row, index) => new List<int>(board.Select(inner => inner[index]))).ToList();

        public static List<List<int>> GetRows(this Board board) => board;

        public static List<List<int>> GetSquares(this Board board)
        {
            Board squares = new Board 
            { 
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>(),
                new List<int>()
            };

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    squares[i].AddRange(board[((i / 3) * 3) + j].GetRange((3 * i) % 9, 3));
                }
            }

            return squares;
        }

        public static List<int> GetColumn(this Board board, int column)
        {
            return board.GetColumns()[column];
        }

        public static List<int> GetRow(this Board board, int row)
        {
            return board.GetRows()[row];
        }

        public static List<int> GetSquare(this Board board, int square)
        {
            return board.GetSquares()[square];
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuLogic
{
    public static class BoardHelpers
    {
        public static List<List<(int, List<int>)>> GetColumns(this Board board) => board.Select((row, index) => new List<(int, List<int>)>(board.Select(inner => inner[index]))).ToList();

        public static List<List<(int, List<int>)>> GetRows(this Board board) => board;

        public static List<List<(int, List<int>)>> GetSquares(this Board board)
        {
            Board squares = new Board 
            { 
                new List<(int, List<int>)>(),
                new List<(int, List<int>)>(),
                new List<(int, List<int>)>(),
                new List<(int, List<int>)>(),
                new List<(int, List<int>)>(),
                new List<(int, List<int>)>(),
                new List<(int, List<int>)>(),
                new List<(int, List<int>)>(),
                new List<(int, List<int>)>()
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

        public static List<(int, List<int>)> GetColumn(this Board board, int column)
        {
            return board.GetColumns()[column];
        }

        public static List<(int, List<int>)> GetRow(this Board board, int row)
        {
            return board.GetRows()[row];
        }

        public static List<(int, List<int>)> GetSquare(this Board board, int square)
        {
            return board.GetSquares()[square];
        }

        public static int GetSquareIndexFromPosition(this Board board, int row, int column)
        {
            return row switch
            {
                int x when x <= 2 && column <= 2 => 0,
                int x when x <= 2 && column <= 5 => 1,
                int x when x <= 2 && column <= 8 => 2,
                int x when x <= 5 && column <= 2 => 3,
                int x when x <= 5 && column <= 5 => 4,
                int x when x <= 5 && column <= 8 => 5,
                int x when x <= 8 && column <= 2 => 6,
                int x when x <= 8 && column <= 5 => 7,
                int x when x <= 8 && column <= 8 => 8,
                _ => throw new ArgumentException(nameof(row))
            };
        }
    }
}

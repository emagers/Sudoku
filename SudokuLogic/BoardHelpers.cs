using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuLogic
{
    public static class BoardHelpers
    {
        public static List<List<BoardItem>> GetColumns(this Board board) => board.Select((row, index) => new List<BoardItem>(board.Select(inner => inner[index]))).ToList();

        public static List<List<BoardItem>> GetRows(this Board board) => board;

        public static List<List<BoardItem>> GetSquares(this Board board)
        {
            Board squares = new Board 
            { 
                new List<BoardItem>(),
                new List<BoardItem>(),
                new List<BoardItem>(),
                new List<BoardItem>(),
                new List<BoardItem>(),
                new List<BoardItem>(),
                new List<BoardItem>(),
                new List<BoardItem>(),
                new List<BoardItem>()
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

        public static List<BoardItem> GetColumn(this Board board, int column)
        {
            return board.GetColumns()[column];
        }

        public static List<BoardItem> GetRow(this Board board, int row)
        {
            return board.GetRows()[row];
        }

        public static List<BoardItem> GetSquare(this Board board, int square)
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

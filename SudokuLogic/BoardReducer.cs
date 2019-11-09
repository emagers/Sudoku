using System.Collections.Generic;
using System.Linq;

namespace SudokuLogic
{
    public static class BoardReducer
    {
        private static int[] Numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        private static List<int> GetEasyPossibilitiesInColumn(Board board, int columnIndex)
        {
            return Numbers.Except(board.GetColumn(columnIndex).Select(x => x.Item1)).ToList();
        }

        private static List<int> GetEasyPossibilitiesInRow(Board board, int rowIndex)
        {
            return Numbers.Except(board.GetRow(rowIndex).Select(x => x.Item1)).ToList();
        }

        private static List<int> GetEasyPossibilitiesInSquare(Board board, int squareIndex)
        {
            return Numbers.Except(board.GetSquare(squareIndex).Select(x => x.Item1)).ToList();
        }

        private static List<int> GetEasyPossibilitiesAtPosition(Board board, int row, int column)
        {
            return GetEasyPossibilitiesInColumn(board, column)
                    .Intersect(GetEasyPossibilitiesInRow(board, row))
                    .Intersect(GetEasyPossibilitiesInSquare(board, board.GetSquareIndexFromPosition(row, column)))
                    .ToList();
        }

        public static void PopulateEasyPossibilities(this Board board)
        {
            for (int i = 0; i < board.Count; i++)
            {
                for (int j = 0; j < board.Count; j++)
                {
                    if (board[i][j].Item1 == 0)
                    {
                        List<int> temp = GetEasyPossibilitiesAtPosition(board, i, j).ToList();
                        if (board[i][j].Item2.Count == 0)
                        {
                            board[i][j].Item2.AddRange(temp);
                        }
                        else
                        {
                            board[i][j].Item2.RemoveAll(x => !temp.Contains(x));
                        }
                    }
                }
            }
        }
    }
}

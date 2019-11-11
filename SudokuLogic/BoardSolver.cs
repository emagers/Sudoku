using SudokuLogic.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuLogic
{
    public static class BoardSolver
    {
        public static void Solve(this Board board)
        {
            int currentEasyCount;
            do
            {
                currentEasyCount = board.GetDifficulties()[Difficulty.EASY];

                board.ReduceEasyPossibilities();
                board.SetPositions();
            } while (board.GetDifficulties()[Difficulty.EASY] > currentEasyCount);
        }
    }
}

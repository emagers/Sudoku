using SudokuLogic.Enums;
using System.Collections.Generic;
using Xunit;

namespace SudokuLogic.Tests
{
    public class BoardTests
    {
        private readonly List<List<int>> boardItems = new List<List<int>>
        {
            new List<int> { 5, 0, 0, 0, 3, 0, 0, 0, 0 },
            new List<int> { 3, 0, 0, 9, 0, 2, 8, 0, 5 },
            new List<int> { 0, 0, 0, 5, 0, 1, 9, 6, 0 },
            new List<int> { 0, 3, 9, 6, 2, 0, 1, 5, 0 },
            new List<int> { 8, 2, 7, 0, 0, 0, 0, 0, 6 },
            new List<int> { 0, 0, 0, 0, 4, 3, 7, 0, 2 },
            new List<int> { 0, 0, 0, 0, 0, 4, 0, 2, 0 },
            new List<int> { 0, 0, 0, 0, 9, 0, 0, 0, 0 },
            new List<int> { 0, 0, 5, 0, 0, 0, 0, 0, 7 }
        };

        [Fact]
        public void PopulatingBoard_ShouldIncrementEasyCountsOnly()
        {
            Board board = new Board(boardItems);

            board.ReduceEasyPossibilities();

            Dictionary<Difficulty, int> counts = board.GetDifficulties();

            Assert.True(counts[Difficulty.EASY] > 0);
            Assert.True(counts[Difficulty.MEDIUM] == 0);
            Assert.True(counts[Difficulty.HARD] == 0);
            Assert.True(counts[Difficulty.EXPERT] == 0);
        }
    }
}

using SudokuLogic.Enums;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SudokuLogic.Tests
{
    public class BoardSolverTests
    {
        private readonly List<List<int>> easyBoardItems = new List<List<int>>
        {
            new List<int> { 0,6,0,0,0,3,0,1,0 },
            new List<int> { 0,0,9,0,7,0,0,0,0 },
            new List<int> { 0,0,4,6,8,5,3,0,0 },
            new List<int> { 0,1,7,0,3,8,4,0,5 },
            new List<int> { 9,0,0,0,2,0,0,0,8 },
            new List<int> { 8,0,3,7,5,0,1,6,0 },
            new List<int> { 0,0,2,5,1,7,6,0,0 },
            new List<int> { 0,0,0,0,6,0,2,0,0 },
            new List<int> { 0,3,0,8,0,0,0,7,0 }
        };

        [Fact]
        public void Solve_Should_CompleteAllFirstPassEasyItems()
        {
            Board board = new Board(easyBoardItems);
            List<int> solution = new List<int> { 2, 6, 8, 4, 9, 3, 5, 1, 7, 3, 5, 9, 2, 7, 1, 8, 4, 6, 1, 7, 4, 6, 8, 5, 3, 9, 2, 6, 1, 7, 9, 3, 8, 4, 2, 5, 9, 4, 5, 1, 2, 6, 7, 3, 8, 8, 2, 3, 7, 5, 4, 1, 6, 9, 4, 9, 2, 5, 1, 7, 6, 8, 3, 7, 8, 1, 3, 6, 9, 2, 5, 4, 5, 3, 6, 8, 4, 2, 9, 7, 1 };

            board.Solve();

            Assert.True(board.IsBoardComplete());
            Assert.Equal(solution, board.SelectMany(row => row.Select(columnItem => columnItem.Value)));
            Assert.True(board.GetDifficulties()[Difficulty.EASY] > 0);
            Assert.True(board.GetDifficulties()[Difficulty.MEDIUM] == 0);
            Assert.True(board.GetDifficulties()[Difficulty.HARD] == 0);
            Assert.True(board.GetDifficulties()[Difficulty.EXPERT] == 0);
        }


    }
}

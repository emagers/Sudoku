using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SudokuLogic.Tests
{
    public class BoardReducerTests
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
        public void EasyPossibilities_ShouldNotPopulate_ForFilledPosition()
        {
            Board board = new Board(boardItems);

            board.PopulateEasyPossibilities();

            Assert.Empty(board[0][0].Possibilities);
            Assert.Empty(board[8][8].Possibilities);
            Assert.Empty(board[2][3].Possibilities);
        }

        [Fact]
        public void EasyPossibilities_ShouldNotAddNewPossibilities_AfterInitialCall()
        {
            Board board = new Board(boardItems);
            board[0][1].Possibilities.Clear();
            board[0][1].Possibilities.Add(8);

            board.PopulateEasyPossibilities();

            Assert.Single(board[0][1].Possibilities);
            Assert.Equal(8, board[0][1].Possibilities.First());
        }

        [Theory]
        [InlineData(new int[] { 1, 4, 6, 7, 8, 9 }, 0, 1)]
        [InlineData(new int[] { 6, 7 }, 1, 4)]
        [InlineData(new int[] { 1, 4, 7 }, 0, 7)]
        public void EasyPossibilities_ShouldIntersectPossibilities_ForRowColumnSquare(IEnumerable<int> expected, int row, int column)
        {
            Board board = new Board(boardItems);

            board.PopulateEasyPossibilities();

            Assert.Equal(expected, board[row][column].Possibilities);
        }

        [Fact]
        public void EasyPossibilities_ShouldGeneratePossibilities_ForEachEmptyPosition()
        {
            Board board = new Board(boardItems);

            board.PopulateEasyPossibilities();

            List<List<int>> allItemPossibilities = board.SelectMany(row => row.Where(item => item.Value == 0).Select(item => item.Possibilities)).ToList();
            allItemPossibilities.ForEach(item =>
            {
                Assert.NotEmpty(item);
            });
        }
    }
}

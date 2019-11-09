using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SudokuLogic.Tests
{
    public class BoardReducerTests
    {
        List<List<int>> boardItems = new List<List<int>>
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

            Assert.Empty(board[0][0].Item2);
            Assert.Empty(board[8][8].Item2);
            Assert.Empty(board[2][3].Item2);
        }

        [Fact]
        public void EasyPossibilities_ShouldNotAddNewPossibilities_AfterInitialCall()
        {
            Board board = new Board(boardItems);
            board[0][1].Item2.Add(8);

            board.PopulateEasyPossibilities();

            Assert.Single(board[0][1].Item2);
            Assert.Equal(8, board[0][1].Item2.First());
        }

        [Fact]
        public void EasyPossibilities_ShouldIntersectPossibilities_ForRowColumnSquare()
        {
            Board board = new Board(boardItems);

            board.PopulateEasyPossibilities();

            Assert.Equal(new List<int> { 1, 4, 6, 7, 8, 9 }, board[0][1].Item2);
        }

        [Fact]
        public void EasyPossibilities_ShouldGeneratePossibilities_ForEachEmptyPosition()
        {
            Board board = new Board(boardItems);

            board.PopulateEasyPossibilities();

            List<List<int>> allItemPossibilities = board.SelectMany(row => row.Where(item => item.Item1 == 0).Select(item => item.Item2)).ToList();
            allItemPossibilities.ForEach(item =>
            {
                Assert.NotEmpty(item);
            });
        }
    }
}

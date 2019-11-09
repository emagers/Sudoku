using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SudokuLogic.Tests
{
    public class BoardHelpersTests
    {
        private static readonly List<List<int>> values = new List<List<int>>
        {
            new List<int> { 5,2,9,4,1,7,8,3,6},
            new List<int> { 8,1,3,2,5,6,9,7,4},
            new List<int> { 4,7,6,8,9,3,2,5,1},
            new List<int> { 6,4,1,5,2,8,3,9,7},
            new List<int> { 3,5,7,6,4,9,1,8,2},
            new List<int> { 9,8,2,3,7,1,6,4,5},
            new List<int> { 7,3,8,1,6,5,4,2,9},
            new List<int> { 1,9,4,7,3,2,5,6,8},
            new List<int> { 2,6,5,9,8,4,7,1,3}
        };

        private static readonly Board board = new Board(values);

        [Fact]
        public void GetRows_Returns_Correct_Rows()
        {
            List<List<(int, List<int>)>> rows = board.GetRows();

            for (int i = 0; i < board.Count; i++)
            {
                Assert.Equal(board[i].Select(x => x.Item1).ToList(), rows[i].Select(x => x.Item1).ToList());
            }
        }

        [Fact]
        public void GetColumns_Returns_Correct_Columns()
        {
            List<List<int>> columns = new List<List<int>>
            {
                new List<int> { 5,8,4,6,3,9,7,1,2},
                new List<int> { 2,1,7,4,5,8,3,9,6},
                new List<int> { 9,3,6,1,7,2,8,4,5},
                new List<int> { 4,2,8,5,6,3,1,7,9},
                new List<int> { 1,5,9,2,4,7,6,3,8},
                new List<int> { 7,6,3,8,9,1,5,2,4},
                new List<int> { 8,9,2,3,1,6,4,5,7},
                new List<int> { 3,7,5,9,8,4,2,6,1},
                new List<int> { 6,4,1,7,2,5,9,8,3}
            };

            Board expectedColumns = new Board(columns);
            Board board = new Board(values);

            List<List<(int, List<int>)>> actualColumns = board.GetColumns();

            for (int i = 0; i < board.Count; i++)
            {
                Assert.Equal(expectedColumns[i].Select(x => x.Item1).ToList(), actualColumns[i].Select(x => x.Item1).ToList());
            }
        }

        [Fact]
        public void GetSquares_Returns_Correct_Squares()
        {
            var expected = new List<List<int>>
            {
                new List<int> { 5,2,9,8,1,3,4,7,6},
                new List<int> { 4,1,7,2,5,6,8,9,3},
                new List<int> { 8,3,6,9,7,4,2,5,1},
                new List<int> { 6,4,1,3,5,7,9,8,2},
                new List<int> { 5,2,8,6,4,9,3,7,1},
                new List<int> { 3,9,7,1,8,2,6,4,5},
                new List<int> { 7,3,8,1,9,4,2,6,5},
                new List<int> { 1,6,5,7,3,2,9,8,4},
                new List<int> { 4,2,9,5,6,8,7,1,3}
            };

            Board expectedSquares = new Board(expected);
            Board board = new Board(values);

            List<List<(int, List<int>)>> actualSquares = board.GetSquares();

            for (int i = 0; i < board.Count; i++)
            {
                Assert.Equal(expectedSquares[i].Select(x => x.Item1).ToList(), actualSquares[i].Select(x => x.Item1).ToList());
            }
        }

        [Theory]
        [InlineData(0, new int[] { 5, 2, 9, 4, 1, 7, 8, 3, 6 })]
        [InlineData(1, new int[] { 8, 1, 3, 2, 5, 6, 9, 7, 4 })]
        [InlineData(2, new int[] { 4, 7, 6, 8, 9, 3, 2, 5, 1 })]
        [InlineData(3, new int[] { 6, 4, 1, 5, 2, 8, 3, 9, 7 })]
        [InlineData(4, new int[] { 3, 5, 7, 6, 4, 9, 1, 8, 2 })]
        [InlineData(5, new int[] { 9, 8, 2, 3, 7, 1, 6, 4, 5 })]
        [InlineData(6, new int[] { 7, 3, 8, 1, 6, 5, 4, 2, 9 })]
        [InlineData(7, new int[] { 1, 9, 4, 7, 3, 2, 5, 6, 8 })]
        [InlineData(8, new int[] { 2, 6, 5, 9, 8, 4, 7, 1, 3 })]
        public void GetRow(int index, IEnumerable<int> expected)
        {
            List<(int, List<int>)> row = board.GetRow(index);

            Assert.Equal(expected, row.Select(x => x.Item1).ToList());
        }

        [Theory]
        [InlineData(0, new int[] { 5, 8, 4, 6, 3, 9, 7, 1, 2 })]
        [InlineData(1, new int[] { 2, 1, 7, 4, 5, 8, 3, 9, 6 })]
        [InlineData(2, new int[] { 9, 3, 6, 1, 7, 2, 8, 4, 5 })]
        [InlineData(3, new int[] { 4, 2, 8, 5, 6, 3, 1, 7, 9 })]
        [InlineData(4, new int[] { 1, 5, 9, 2, 4, 7, 6, 3, 8 })]
        [InlineData(5, new int[] { 7, 6, 3, 8, 9, 1, 5, 2, 4 })]
        [InlineData(6, new int[] { 8, 9, 2, 3, 1, 6, 4, 5, 7 })]
        [InlineData(7, new int[] { 3, 7, 5, 9, 8, 4, 2, 6, 1 })]
        [InlineData(8, new int[] { 6, 4, 1, 7, 2, 5, 9, 8, 3 })]
        public void GetColumn(int index, IEnumerable<int> expected)
        {
            List<(int, List<int>)> column = board.GetColumn(index);

            Assert.Equal(expected, column.Select(x => x.Item1).ToList());
        }

        [Theory]
        [InlineData(0, new int[] { 5, 2, 9, 8, 1, 3, 4, 7, 6 })]
        [InlineData(1, new int[] { 4, 1, 7, 2, 5, 6, 8, 9, 3 })]
        [InlineData(2, new int[] { 8, 3, 6, 9, 7, 4, 2, 5, 1 })]
        [InlineData(3, new int[] { 6, 4, 1, 3, 5, 7, 9, 8, 2 })]
        [InlineData(4, new int[] { 5, 2, 8, 6, 4, 9, 3, 7, 1 })]
        [InlineData(5, new int[] { 3, 9, 7, 1, 8, 2, 6, 4, 5 })]
        [InlineData(6, new int[] { 7, 3, 8, 1, 9, 4, 2, 6, 5 })]
        [InlineData(7, new int[] { 1, 6, 5, 7, 3, 2, 9, 8, 4 })]
        [InlineData(8, new int[] { 4, 2, 9, 5, 6, 8, 7, 1, 3 })]
        public void GetSquare(int index, IEnumerable<int> expected)
        {
            List<(int, List<int>)> square = board.GetSquare(index);

            Assert.Equal(expected, square.Select(x => x.Item1).ToList());
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(0, 1, 0)]
        [InlineData(0, 2, 0)]
        [InlineData(1, 0, 0)]
        [InlineData(1, 1, 0)]
        [InlineData(1, 2, 0)]
        [InlineData(2, 0, 0)]
        [InlineData(2, 1, 0)]
        [InlineData(2, 2, 0)]
        [InlineData(0, 3, 1)]
        [InlineData(0, 4, 1)]
        [InlineData(0, 5, 1)]
        [InlineData(1, 3, 1)]
        [InlineData(1, 4, 1)]
        [InlineData(1, 5, 1)]
        [InlineData(2, 3, 1)]
        [InlineData(2, 4, 1)]
        [InlineData(2, 5, 1)]
        [InlineData(0, 6, 2)]
        [InlineData(0, 7, 2)]
        [InlineData(0, 8, 2)]
        [InlineData(1, 6, 2)]
        [InlineData(1, 7, 2)]
        [InlineData(1, 8, 2)]
        [InlineData(2, 6, 2)]
        [InlineData(2, 7, 2)]
        [InlineData(2, 8, 2)]
        [InlineData(3, 0, 3)]
        [InlineData(3, 1, 3)]
        [InlineData(3, 2, 3)]
        [InlineData(4, 0, 3)]
        [InlineData(4, 1, 3)]
        [InlineData(4, 2, 3)]
        [InlineData(5, 0, 3)]
        [InlineData(5, 1, 3)]
        [InlineData(5, 2, 3)]
        [InlineData(3, 3, 4)]
        [InlineData(3, 4, 4)]
        [InlineData(3, 5, 4)]
        [InlineData(4, 3, 4)]
        [InlineData(4, 4, 4)]
        [InlineData(4, 5, 4)]
        [InlineData(5, 3, 4)]
        [InlineData(5, 4, 4)]
        [InlineData(5, 5, 4)]
        [InlineData(3, 6, 5)]
        [InlineData(3, 7, 5)]
        [InlineData(3, 8, 5)]
        [InlineData(4, 6, 5)]
        [InlineData(4, 7, 5)]
        [InlineData(4, 8, 5)]
        [InlineData(5, 6, 5)]
        [InlineData(5, 7, 5)]
        [InlineData(5, 8, 5)]
        [InlineData(6, 0, 6)]
        [InlineData(6, 1, 6)]
        [InlineData(6, 2, 6)]
        [InlineData(7, 0, 6)]
        [InlineData(7, 1, 6)]
        [InlineData(7, 2, 6)]
        [InlineData(8, 0, 6)]
        [InlineData(8, 1, 6)]
        [InlineData(8, 2, 6)]
        [InlineData(6, 3, 7)]
        [InlineData(6, 4, 7)]
        [InlineData(6, 5, 7)]
        [InlineData(7, 3, 7)]
        [InlineData(7, 4, 7)]
        [InlineData(7, 5, 7)]
        [InlineData(8, 3, 7)]
        [InlineData(8, 4, 7)]
        [InlineData(8, 5, 7)]
        [InlineData(6, 6, 8)]
        [InlineData(6, 7, 8)]
        [InlineData(6, 8, 8)]
        [InlineData(7, 6, 8)]
        [InlineData(7, 7, 8)]
        [InlineData(7, 8, 8)]
        [InlineData(8, 6, 8)]
        [InlineData(8, 7, 8)]
        [InlineData(8, 8, 8)]
        public void GetSquareIndexFromPosition(int row, int column, int expected)
        {
            Assert.Equal(expected, board.GetSquareIndexFromPosition(row, column));
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SudokuLogic.Tests
{
    public class BoardValidatorTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, true)]
        [InlineData(new int[] { 1, 2, 0, 4, 5, 0, 7, 8, 9 }, true)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 5, 7, 8, 9 }, false)]
        public void IsLineValid(IEnumerable<int> line, bool expected)
        {
            List<int> realLine = line.ToList();

            bool actual = BoardValidator.IsLineValid(realLine);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, true)]
        [InlineData(new int[] { 1, 2, 0, 4, 5, 0, 7, 8, 9 }, false)]
        [InlineData(new int[] { 1, 2, 3, 4, 5, 5, 7, 8, 9 }, false)]
        public void IsLineComplete(IEnumerable<int> line, bool expected)
        {
            List<int> realLine = line.ToList();

            bool actual = BoardValidator.IsLineComplete(realLine);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsBoardComplete_When_Valid_Should_Be_True()
        {
            Board board = new Board
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

            Assert.True(BoardValidator.IsBoardComplete(board));
        }

        [Fact]
        public void IsBoardComplete_When_Invalid_Should_Be_False()
        {
            Board board = new Board
            {
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
            };

            Assert.False(BoardValidator.IsBoardComplete(board));
        }

        [Fact]
        public void IsBoardComplete_Empty_Values_Should_Be_False()
        {
            Board board = new Board
            {
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 0, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
                new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
            };

            Assert.False(BoardValidator.IsBoardComplete(board));
        }

        [Fact]
        public void IsBoardValid_When_Complete_Should_Be_True()
        {
            Board board = new Board
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

            Assert.True(BoardValidator.IsBoardValid(board));
        }

        [Fact]
        public void IsBoardValid_When_Incomplete_Should_Be_True()
        {
            Board board = new Board
            {
                new List<int> { 0,2,9,4,1,7,8,3,6},
                new List<int> { 8,1,3,2,5,6,9,7,4},
                new List<int> { 4,7,6,8,9,3,2,5,1},
                new List<int> { 6,4,1,5,2,8,3,9,7},
                new List<int> { 3,5,7,6,4,9,1,8,2},
                new List<int> { 9,8,2,3,7,1,6,4,5},
                new List<int> { 7,3,8,1,6,5,4,2,9},
                new List<int> { 1,9,4,7,3,2,5,6,8},
                new List<int> { 2,6,5,9,8,4,7,1,0}
            };

            Assert.True(BoardValidator.IsBoardValid(board));
        }

        [Fact]
        public void IsBoardValid_Should_Be_False_When_Duplicates_In_Column()
        {
            Board board = new Board
            {
                new List<int> { 5,2,1,4,1,7,8,3,6},
                new List<int> { 8,0,3,2,5,6,9,7,4},
                new List<int> { 4,7,6,8,9,3,2,5,1},
                new List<int> { 6,4,0,5,2,8,3,9,7},
                new List<int> { 3,5,7,6,4,9,1,8,2},
                new List<int> { 9,8,2,3,7,1,6,4,5},
                new List<int> { 7,3,8,1,6,5,4,2,9},
                new List<int> { 1,9,4,7,3,2,5,6,8},
                new List<int> { 2,6,5,9,8,4,7,1,3}
            };

            Assert.False(BoardValidator.IsBoardValid(board));
        }

        [Fact]
        public void IsBoardValid_Should_Be_False_When_Duplicates_In_Row()
        {
            Board board = new Board
            {
                new List<int> { 5,2,9,4,1,7,8,3,6},
                new List<int> { 8,1,3,2,5,6,9,7,4},
                new List<int> { 4,7,6,8,9,3,2,5,1},
                new List<int> { 6,2,1,5,0,8,3,9,7},
                new List<int> { 3,5,7,6,4,9,1,8,2},
                new List<int> { 9,8,0,3,7,1,6,4,5},
                new List<int> { 7,3,8,1,6,5,4,2,9},
                new List<int> { 1,9,4,7,3,2,5,6,8},
                new List<int> { 2,6,5,9,8,4,7,1,3}
            };

            Assert.False(BoardValidator.IsBoardValid(board));
        }

        [Fact]
        public void IsBoardValid_Should_Be_False_When_Duplicates_In_Box()
        {
            Board board = new Board
            {
                new List<int> { 5,2,9,4,1,7,8,3,6},
                new List<int> { 8,2,3,0,5,6,9,7,4},
                new List<int> { 4,7,6,8,9,3,2,5,1},
                new List<int> { 6,4,1,5,2,8,3,9,7},
                new List<int> { 3,5,7,6,4,9,1,8,2},
                new List<int> { 9,8,2,3,7,1,6,4,5},
                new List<int> { 7,3,8,1,6,5,4,2,9},
                new List<int> { 1,9,4,7,3,2,5,6,8},
                new List<int> { 2,6,5,9,8,4,7,1,3}
            };

            Assert.False(BoardValidator.IsBoardValid(board));
        }
    }
}

using MetaTicTacToe.Models;
using Xunit;

namespace MetaTicTacToe.Tests.Models
{
    public class BoardTests
    {
        [Fact]
        public void Board_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var board = new Board();

            // Assert
            Assert.Equal(3, board.Cells.Length);
            foreach (var row in board.Cells)
            {
                Assert.Equal(3, row.Length);
                foreach (var cell in row)
                {
                    Assert.NotNull(cell);
                    Assert.True(cell.Empty);
                }
            }
            Assert.Null(board.Winner);
            Assert.False(board.IsFull);
        }

        [Fact]
        public void Board_ShouldSetAndGetId()
        {
            // Arrange
            var board = new Board();
            var id = 1;

            // Act
            board.Id = id;

            // Assert
            Assert.Equal(id, board.Id);
        }

        [Fact]
        public void Board_ShouldSetAndGetWinner()
        {
            // Arrange
            var player = new Player("Player1", true);
            var board = new Board();

            // Act
            board.Winner = player;

            // Assert
            Assert.Equal(player, board.Winner);
            Assert.False(board.IsFull);
        }

        [Fact]
        public void Board_IsFull_ShouldReturnFalseIfWinnerIsNotNull()
        {
            // Arrange
            var player = new Player("Player1", true);
            var board = new Board { Winner = player };

            // Act
            var isFull = board.IsFull;

            // Assert
            Assert.False(isFull);
        }

        [Fact]
        public void Board_IsFull_ShouldReturnFalseIfAnyCellIsEmpty()
        {
            // Arrange
            var board = new Board();
            board.Cells[0][0].Value = new Player("Player1", true);

            // Act
            var isFull = board.IsFull;

            // Assert
            Assert.False(isFull);
        }

        [Fact]
        public void Board_IsFull_ShouldReturnTrueIfAllCellsAreFilledAndNoWinner()
        {
            // Arrange
            var board = new Board();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board.Cells[i][j].Value = new Player($"Player{i}{j}", i % 2 == 0);
                }
            }

            // Act
            var isFull = board.IsFull;

            // Assert
            Assert.True(isFull);
        }
    }
}

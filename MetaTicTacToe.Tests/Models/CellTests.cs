using MetaTicTacToe.Models;
using Xunit;

namespace MetaTicTacToe.Tests.Models
{
    public class CellTests
    {
        [Fact]
        public void Cell_ShouldInitializeWithNullValue()
        {
            // Arrange & Act
            var cell = new Cell();

            // Assert
            Assert.Null(cell.Value);
            Assert.True(cell.Empty);
            Assert.False(cell.Filled);
        }

        [Fact]
        public void Cell_ShouldSetAndGetValue()
        {
            // Arrange
            var player = new Player("Player1", true);
            var cell = new Cell();

            // Act
            cell.Value = player;

            // Assert
            Assert.Equal(player, cell.Value);
            Assert.False(cell.Empty);
            Assert.True(cell.Filled);
            Assert.Equal(player, cell.Winner);
        }

        [Theory]
        [InlineData(true, "X")]
        [InlineData(false, "O")]
        public void Cell_ToString_ShouldReturnCorrectSymbol(bool symbol, string expectedSymbol)
        {
            // Arrange
            var player = new Player("Player", symbol);
            var cell = new Cell { Value = player };

            // Act
            var result = cell.ToString();

            // Assert
            Assert.Equal(expectedSymbol, result);
        }

        [Fact]
        public void Cell_Equals_ShouldReturnTrueForEqualValues()
        {
            // Arrange
            var player = new Player("Player1", true);
            var cell1 = new Cell { Value = player };
            var cell2 = new Cell { Value = player };

            // Act & Assert
            Assert.True(cell1 == cell2);
            Assert.True(cell1.Equals(cell2));
        }

        [Fact]
        public void Cell_Equals_ShouldReturnFalseForDifferentValues()
        {
            // Arrange
            var player1 = new Player("Player1", true);
            var player2 = new Player("Player2", false);
            var cell1 = new Cell { Value = player1 };
            var cell2 = new Cell { Value = player2 };

            // Act & Assert
            Assert.False(cell1 == cell2);
            Assert.False(cell1.Equals(cell2));
        }

        [Fact]
        public void Cell_GetHashCode_ShouldReturnSameHashCodeForEqualValues()
        {
            // Arrange
            var player = new Player("Player1", true);
            var cell1 = new Cell { Value = player };
            var cell2 = new Cell { Value = player };

            // Act & Assert
            Assert.Equal(cell1.GetHashCode(), cell2.GetHashCode());
        }

        [Fact]
        public void Cell_GetHashCode_ShouldReturnDifferentHashCodeForDifferentValues()
        {
            // Arrange
            var player1 = new Player("Player1", true);
            var player2 = new Player("Player2", false);
            var cell1 = new Cell { Value = player1 };
            var cell2 = new Cell { Value = player2 };

            // Act & Assert
            Assert.NotEqual(cell1.GetHashCode(), cell2.GetHashCode());
        }

        [Fact]
        public void Cell_EqualityOperator_ShouldReturnTrueForNullCells()
        {
            // Arrange
            Cell cell1 = null;
            Cell cell2 = null;

            // Act & Assert
            Assert.True(cell1 == cell2);
        }

        [Fact]
        public void Cell_InequalityOperator_ShouldReturnFalseForNullCells()
        {
            // Arrange
            Cell cell1 = null;
            Cell cell2 = null;

            // Act & Assert
            Assert.False(cell1 != cell2);
        }

        [Fact]
        public void Cell_EqualityOperator_ShouldReturnFalseForOneNullCell()
        {
            // Arrange
            var player = new Player("Player1", true);
            var cell1 = new Cell { Value = player };
            Cell cell2 = null;

            // Act & Assert
            Assert.False(cell1 == cell2);
        }

        [Fact]
        public void Cell_InequalityOperator_ShouldReturnTrueForOneNullCell()
        {
            // Arrange
            var player = new Player("Player1", true);
            var cell1 = new Cell { Value = player };
            Cell cell2 = null;

            // Act & Assert
            Assert.True(cell1 != cell2);
        }
    }
}

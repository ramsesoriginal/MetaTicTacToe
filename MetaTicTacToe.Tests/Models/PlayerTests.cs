using MetaTicTacToe.Models;
using Xunit;

namespace MetaTicTacToe.Tests.Models
{
    public class PlayerTests
    {
        [Fact]
        public void Player_ShouldInitializeWithCorrectValues()
        {
            // Arrange
            var name = "Player1";
            var symbol = true;

            // Act
            var player = new Player(name, symbol);

            // Assert
            Assert.Equal(name, player.Name);
            Assert.Equal(symbol, player.Symbol);
        }

        [Theory]
        [InlineData(true, "X")]
        [InlineData(false, "O")]
        public void Player_ToString_ShouldReturnCorrectSymbol(bool symbol, string expectedSymbol)
        {
            // Arrange
            var player = new Player("Player", symbol);

            // Act
            var result = player.ToString();

            // Assert
            Assert.Equal(expectedSymbol, result);
        }

        [Fact]
        public void Player_Name_ShouldBeSettable()
        {
            // Arrange
            var player = new Player("InitialName", true);

            // Act
            player.Name = "NewName";

            // Assert
            Assert.Equal("NewName", player.Name);
        }

        [Fact]
        public void Player_Symbol_ShouldBeSettable()
        {
            // Arrange
            var player = new Player("Player", true);

            // Act
            player.Symbol = false;

            // Assert
            Assert.False(player.Symbol);
        }

        [Fact]
        public void Player_WithNullName_ShouldThrowArgumentNullException()
        {
            // Arrange, Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Player(null, true));
        }
    }
}

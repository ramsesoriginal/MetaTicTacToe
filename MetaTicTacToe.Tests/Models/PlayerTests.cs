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
            Assert.True(player.Symbol);
        }

        [Fact]
        public void Player_ToString_ShouldReturnCorrectSymbol()
        {
            // Arrange
            var playerX = new Player("Player1", true);
            var playerO = new Player("Player2", false);

            // Act & Assert
            Assert.Equal("X", playerX.ToString());
            Assert.Equal("O", playerO.ToString());
        }
    }
}

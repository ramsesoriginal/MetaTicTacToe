using MetaTicTacToe.Models;
using MetaTicTacToe.Models.Rules;
using Xunit;

namespace MetaTicTacToe.Tests.Models.Rules
{
    public class CorrectPlayerRuleTests
    {
        [Fact]
        public void IsMoveValid_ShouldReturnTrue_WhenPlayerIsCurrentPlayer()
        {
            // Arrange
            var game = new Game
            {
                Player1 = new Player("Player1", true),
                Player2 = new Player("Player2", false),
                CurrentPlayer = new Player("Player1", true)
            };
            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };
            var rule = new CorrectPlayerRule();

            // Act
            var result = rule.IsMoveValid(game, move);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsMoveValid_ShouldReturnFalse_WhenPlayerIsNotCurrentPlayer()
        {
            // Arrange
            var game = new Game
            {
                Player1 = new Player("Player1", true),
                Player2 = new Player("Player2", false),
                CurrentPlayer = new Player("Player1", true)
            };
            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = false
            };
            var rule = new CorrectPlayerRule();

            // Act
            var result = rule.IsMoveValid(game, move);

            // Assert
            Assert.False(result);
        }
    }
}

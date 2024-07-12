using MetaTicTacToe.Models;
using Xunit;

namespace MetaTicTacToe.Tests.Models
{
    public class GameTests
    {
        [Fact]
        public void Game_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var game = new Game();

            // Assert
            Assert.Equal(3, game.Boards.Length);
            foreach (var boardRow in game.Boards)
            {
                Assert.Equal(3, boardRow.Length);
                foreach (var board in boardRow)
                {
                    Assert.NotNull(board);
                }
            }
            Assert.Null(game.Winner);
            Assert.Null(game.CurrentPlayer);
            Assert.Null(game.Player1);
            Assert.Null(game.Player2);
        }

        [Fact]
        public void Game_ShouldSetAndGetId()
        {
            // Arrange
            var game = new Game();
            var id = 1;

            // Act
            game.Id = id;

            // Assert
            Assert.Equal(id, game.Id);
        }

        [Fact]
        public void Game_ShouldSetAndGetPlayers()
        {
            // Arrange
            var player1 = new Player("Player1", true);
            var player2 = new Player("Player2", false);
            var game = new Game();

            // Act
            game.Player1 = player1;
            game.Player2 = player2;

            // Assert
            Assert.Equal(player1, game.Player1);
            Assert.Equal(player2, game.Player2);
        }

        [Fact]
        public void Game_ShouldSetAndGetCurrentPlayer()
        {
            // Arrange
            var player = new Player("Player1", true);
            var game = new Game();

            // Act
            game.CurrentPlayer = player;

            // Assert
            Assert.Equal(player, game.CurrentPlayer);
        }

        [Fact]
        public void Game_ShouldSetAndGetWinner()
        {
            // Arrange
            var player = new Player("Player1", true);
            var game = new Game();

            // Act
            game.Winner = player;

            // Assert
            Assert.Equal(player, game.Winner);
        }

        [Fact]
        public void Game_Boards_ShouldInitializeWithDefaultValues()
        {
            // Arrange & Act
            var game = new Game();

            // Assert
            Assert.Equal(3, game.Boards.Length);
            foreach (var row in game.Boards)
            {
                Assert.Equal(3, row.Length);
                foreach (var board in row)
                {
                    Assert.NotNull(board);
                }
            }
        }
    }
}

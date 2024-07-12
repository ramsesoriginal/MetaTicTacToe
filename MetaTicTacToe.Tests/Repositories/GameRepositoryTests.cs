using MetaTicTacToe.Models;
using MetaTicTacToe.Repositories;
using System.Collections.Generic;
using Xunit;

namespace MetaTicTacToe.Tests.Repositories
{
    public class GameRepositoryTests
    {
        [Fact]
        public void AddGame_ShouldAddGameToRepository()
        {
            // Arrange
            var repository = new GameRepository();
            var game = new Game();

            // Act
            var addedGame = repository.AddGame(game);

            // Assert
            Assert.Equal(1, addedGame.Id);
            Assert.Single(repository.GetAllGames());
        }

        [Fact]
        public void GetGame_ShouldReturnGameById()
        {
            // Arrange
            var repository = new GameRepository();
            var game = new Game();
            repository.AddGame(game);

            // Act
            var retrievedGame = repository.GetGame(1);

            // Assert
            Assert.NotNull(retrievedGame);
            Assert.Equal(1, retrievedGame.Id);
        }

        [Fact]
        public void GetGame_ShouldReturnNullIfGameNotFound()
        {
            // Arrange
            var repository = new GameRepository();

            // Act
            var retrievedGame = repository.GetGame(1);

            // Assert
            Assert.Null(retrievedGame);
        }

        [Fact]
        public void GetAllGames_ShouldReturnAllGames()
        {
            // Arrange
            var repository = new GameRepository();
            repository.AddGame(new Game());
            repository.AddGame(new Game());

            // Act
            var games = repository.GetAllGames();

            // Assert
            Assert.Equal(2, ((List<Game>)games).Count);
        }

        [Fact]
        public void UpdateGame_ShouldUpdateExistingGame()
        {
            // Arrange
            var repository = new GameRepository();
            var game = new Game { Id = 1 };
            repository.AddGame(game);
            var updatedGame = new Game { Id = 1, CurrentPlayer = new Player("Player1", true) };

            // Act
            repository.UpdateGame(updatedGame);
            var retrievedGame = repository.GetGame(1);

            // Assert
            Assert.NotNull(retrievedGame);
            Assert.Equal("Player1", retrievedGame.CurrentPlayer.Name);
        }

        [Fact]
        public void UpdateGame_ShouldNotAddNewGameIfNotFound()
        {
            // Arrange
            var repository = new GameRepository();
            var game = new Game { Id = 1, CurrentPlayer = new Player("Player1", true) };

            // Act
            repository.UpdateGame(game);
            var retrievedGame = repository.GetGame(1);

            // Assert
            Assert.Null(retrievedGame);
        }
    }
}

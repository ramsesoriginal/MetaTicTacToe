using MetaTicTacToe.Controllers;
using MetaTicTacToe.Models;
using MetaTicTacToe.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MetaTicTacToe.Tests.Controllers
{
    public class GameControllerTests
    {
        private readonly Mock<IGameService> _mockGameService;
        private readonly GameController _gameController;

        public GameControllerTests()
        {
            _mockGameService = new Mock<IGameService>();
            _gameController = new GameController(_mockGameService.Object);
        }

        [Fact]
        public void StartGame_ShouldReturnOkResult_WithGame()
        {
            // Arrange
            var game = new Game();
            _mockGameService.Setup(service => service.StartGame()).Returns(game);

            // Act
            var result = _gameController.StartGame();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedGame = Assert.IsType<Game>(okResult.Value);
            Assert.Equal(game, returnedGame);
        }

        [Fact]
        public void MakeMove_ShouldReturnOkResult_WithUpdatedGame()
        {
            // Arrange
            var game = new Game();
            var move = new Move { GameId = 1, BoardRow = 0, BoardColumn = 0, CellRow = 0, CellColumn = 0, Player = true };
            _mockGameService.Setup(service => service.MakeMove(move)).Returns(game);

            // Act
            var result = _gameController.MakeMove(move);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedGame = Assert.IsType<Game>(okResult.Value);
            Assert.Equal(game, returnedGame);
        }

        [Fact]
        public void GetGameStatus_ShouldReturnOkResult_WithGame()
        {
            // Arrange
            var game = new Game { Id = 1 };
            _mockGameService.Setup(service => service.GetGameStatus(1)).Returns(game);

            // Act
            var result = _gameController.GetGameStatus(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedGame = Assert.IsType<Game>(okResult.Value);
            Assert.Equal(game, returnedGame);
        }

        [Fact]
        public void GetGameStatus_ShouldReturnNotFound_WhenGameNotFound()
        {
            // Arrange
            _mockGameService.Setup(service => service.GetGameStatus(1)).Returns<Game>(null);

            // Act
            var result = _gameController.GetGameStatus(1);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result.Result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}

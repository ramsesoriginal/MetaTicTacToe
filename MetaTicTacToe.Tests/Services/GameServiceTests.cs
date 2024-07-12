using MetaTicTacToe.Models;
using MetaTicTacToe.Repositories;
using MetaTicTacToe.Services;
using Moq;
using System;
using Xunit;

namespace MetaTicTacToe.Tests.Services
{
    public class GameServiceTests
    {
        private readonly Mock<IGameRepository> _mockGameRepository;
        private readonly Mock<IRuleService> _mockRuleService;
        private readonly GameService _gameService;

        public GameServiceTests()
        {
            _mockGameRepository = new Mock<IGameRepository>();
            _mockRuleService = new Mock<IRuleService>();
            _gameService = new GameService(_mockGameRepository.Object, _mockRuleService.Object);
        }

        [Fact]
        public void StartGame_ShouldInitializeNewGame()
        {
            // Arrange
            _mockGameRepository.Setup(repo => repo.AddGame(It.IsAny<Game>())).Returns((Game game) => game);

            // Act
            var game = _gameService.StartGame();

            // Assert
            Assert.NotNull(game);
            Assert.NotNull(game.Player1);
            Assert.NotNull(game.Player2);
            Assert.NotNull(game.CurrentPlayer);
            Assert.Equal(game.Player1, game.CurrentPlayer);
            Assert.Equal(9, game.Boards.Length * game.Boards[0].Length);
        }

        [Fact]
        public void MakeMove_ShouldUpdateGameAndChangeCurrentPlayer()
        {
            // Arrange
            Player player = new Player("Player1", true);
            var game = new Game
            {
                Id = 1,
                Player1 = player,
                Player2 = new Player("Player2", false),
                CurrentPlayer = player
            };
            game.Boards[0][0] = new Board();
            _mockGameRepository.Setup(repo => repo.GetGame(1)).Returns(game);
            _mockRuleService.Setup(service => service.ValidateMove(It.IsAny<Game>(), It.IsAny<Move>())).Returns(true);

            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };

            // Act
            var updatedGame = _gameService.MakeMove(move);

            // Assert
            Assert.NotNull(updatedGame);
            Assert.Equal(game.Player2.Name, updatedGame.CurrentPlayer.Name);
            Assert.Equal(game.Player2, updatedGame.CurrentPlayer);
            _mockGameRepository.Verify(repo => repo.UpdateGame(It.IsAny<Game>()), Times.Once);
            Assert.Equal(move, updatedGame.LastMove);
        }

        [Fact]
        public void MakeMove_IsInvalidMove()
        {
            // Arrange
            Player player = new Player("Player1", true);
            var game = new Game
            {
                Id = 1,
                Player1 = player,
                Player2 = new Player("Player2", false),
                CurrentPlayer = player
            };
            game.Boards[0][0] = new Board();
            _mockGameRepository.Setup(repo => repo.GetGame(1)).Returns(game);
            _mockRuleService.Setup(service => service.ValidateMove(It.IsAny<Game>(), It.IsAny<Move>())).Returns(false);

            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _gameService.MakeMove(move));
        }


        [Fact]
        public void MakeMove_ShouldThrowException_WhenInvalidGameId()
        {
            // Arrange
            _mockGameRepository.Setup(repo => repo.GetGame(It.IsAny<int>())).Returns<Game>(null);

            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _gameService.MakeMove(move));
        }

        [Fact]
        public void MakeMove_ShouldThrowException_WhenInvalidBoard()
        {
            // Arrange
            var game = new Game
            {
                Id = 1,
                Player1 = new Player("Player1", true),
                Player2 = new Player("Player2", false),
                CurrentPlayer = new Player("Player1", true)
            };
            _mockGameRepository.Setup(repo => repo.GetGame(1)).Returns(game);

            var move = new Move
            {
                GameId = 1,
                BoardRow = 3,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _gameService.MakeMove(move));
        }

        [Fact]
        public void MakeMove_ShouldThrowException_WhenCellAlreadyOccupied()
        {
            // Arrange
            var game = new Game
            {
                Id = 1,
                Player1 = new Player("Player1", true),
                Player2 = new Player("Player2", false),
                CurrentPlayer = new Player("Player1", true)
            };
            game.Boards[0][0] = new Board();
            game.Boards[0][0].Cells[0][0] = new Cell { Value = game.Player1 };
            _mockGameRepository.Setup(repo => repo.GetGame(1)).Returns(game);

            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _gameService.MakeMove(move));
        }

        [Fact]
        public void MakeMove_ShouldThrowException_WhenWrongPlayer()
        {
            // Arrange
            var game = new Game
            {
                Id = 1,
                Player1 = new Player("Player1", true),
                Player2 = new Player("Player2", false),
                CurrentPlayer = new Player("Player1", true)
            };
            game.Boards[0][0] = new Board();
            _mockGameRepository.Setup(repo => repo.GetGame(1)).Returns(game);

            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = false
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => _gameService.MakeMove(move));
        }

        [Fact]
        public void GetGameStatus_ShouldReturnGame()
        {
            // Arrange
            var game = new Game { Id = 1 };
            _mockGameRepository.Setup(repo => repo.GetGame(1)).Returns(game);

            // Act
            var result = _gameService.GetGameStatus(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetGameStatus_ShouldReturnNullIfGameNotFound()
        {
            // Arrange
            _mockGameRepository.Setup(repo => repo.GetGame(It.IsAny<int>())).Returns<Game>(null);

            // Act
            var result = _gameService.GetGameStatus(1);

            // Assert
            Assert.Null(result);
        }
    }
}

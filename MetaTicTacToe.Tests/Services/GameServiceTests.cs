using MetaTicTacToe.Models;
using MetaTicTacToe.Repositories;
using MetaTicTacToe.Services;
using Moq;
using Xunit;

namespace MetaTicTacToe.Tests.Services
{
    public class GameServiceTests
    {
        private readonly Mock<IGameRepository> _mockRepo;
        private readonly GameService _gameService;

        public GameServiceTests()
        {
            _mockRepo = new Mock<IGameRepository>();
            _gameService = new GameService(_mockRepo.Object);
        }

        [Fact]
        public void CreateGame_ShouldReturnNewGame()
        {
            /*TODO*/
        }
    }
}

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
        private readonly Mock<IGameService> _mockService;
        private readonly GameController _controller;

        public GameControllerTests()
        {
            _mockService = new Mock<IGameService>();
            _controller = new GameController(_mockService.Object);
        }

        [Fact]
        public void GetGame_ShouldReturnOkWithGame()
        {
            /*TODO*/
        }
    }
}

using MetaTicTacToe.Models;
using MetaTicTacToe.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace MetaTicTacToe.Tests.Services
{
    public class RuleServiceTests
    {
        private readonly Mock<IRule> _mockRule1;
        private readonly Mock<IRule> _mockRule2;
        private readonly RuleService _ruleService;

        public RuleServiceTests()
        {
            _mockRule1 = new Mock<IRule>();
            _mockRule2 = new Mock<IRule>();
            var rules = new List<IRule> { _mockRule1.Object, _mockRule2.Object };
            _ruleService = new RuleService(rules);
        }

        [Fact]
        public void ValidateMove_ShouldReturnTrue_WhenAllRulesPass()
        {
            // Arrange
            var game = new Game();
            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };
            _mockRule1.Setup(r => r.IsMoveValid(game, move)).Returns(true);
            _mockRule2.Setup(r => r.IsMoveValid(game, move)).Returns(true);

            // Act
            var result = _ruleService.ValidateMove(game, move);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateMove_ShouldReturnFalse_WhenAnyRuleFails()
        {
            // Arrange
            var game = new Game();
            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };
            _mockRule1.Setup(r => r.IsMoveValid(game, move)).Returns(true);
            _mockRule2.Setup(r => r.IsMoveValid(game, move)).Returns(false);

            // Act
            var result = _ruleService.ValidateMove(game, move);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateMove_ShouldReturnFalse_WhenAllRulesFail()
        {
            // Arrange
            var game = new Game();
            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };
            _mockRule1.Setup(r => r.IsMoveValid(game, move)).Returns(false);
            _mockRule2.Setup(r => r.IsMoveValid(game, move)).Returns(false);

            // Act
            var result = _ruleService.ValidateMove(game, move);

            // Assert
            Assert.False(result);
        }
    }
}

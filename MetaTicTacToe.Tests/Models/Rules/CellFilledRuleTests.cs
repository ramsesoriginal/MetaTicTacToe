using MetaTicTacToe.Models;
using MetaTicTacToe.Models.Rules;
using Xunit;

namespace MetaTicTacToe.Tests.Models.Rules
{
    public class CellFilledRuleTests
    {
        [Fact]
        public void IsMoveValid_ShouldReturnTrue_WhenCellIsNotFilled()
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
            var rule = new CellFilledRule();

            // Act
            var result = rule.IsMoveValid(game, move);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsMoveValid_ShouldReturnFalse_WhenCellIsFilled()
        {
            // Arrange
            var filledCellBoard = new Board
            {
                Cells = new Cell[3][]
                {
                    new Cell[3] { new Cell { Value = new Player("Player1", true) }, new Cell(), new Cell() },
                    new Cell[3] { new Cell(), new Cell(), new Cell() },
                    new Cell[3] { new Cell(), new Cell(), new Cell() }
                }
            };
            var game = new Game
            {
                Boards = new Board[3][]
                {
                    new Board[3] { filledCellBoard, new Board(), new Board() },
                    new Board[3] { new Board(), new Board(), new Board() },
                    new Board[3] { new Board(), new Board(), new Board() }
                }
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
            var rule = new CellFilledRule();

            // Act
            var result = rule.IsMoveValid(game, move);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsMoveValid_ShouldThrowArgumentException_WhenCellIsInvalid()
        {
            // Arrange
            var game = new Game
            {
                Boards = new Board[3][]
                {
                    new Board[3] { new Board(), new Board(), new Board() },
                    new Board[3] { new Board(), new Board(), new Board() },
                    new Board[3] { new Board(), new Board(), new Board() }
                }
            };
            var move = new Move
            {
                GameId = 1,
                BoardRow = 0,
                BoardColumn = 0,
                CellRow = 3, // Invalid row
                CellColumn = 0,
                Player = true
            };
            var rule = new CellFilledRule();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => rule.IsMoveValid(game, move));
        }
    }
}

using MetaTicTacToe.Models;
using MetaTicTacToe.Models.Rules;
using Xunit;

namespace MetaTicTacToe.Tests.Models.Rules
{
    public class BoardDoneRuleTests
    {
        [Fact]
        public void IsMoveValid_ShouldReturnTrue_WhenBoardIsNotFull()
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
            var rule = new BoardDoneRule();

            // Act
            var result = rule.IsMoveValid(game, move);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsMoveValid_ShouldReturnFalse_WhenBoardIsFull()
        {
            // Arrange
            var fullBoard = new Board
            {
                Cells = new Cell[3][]
                {
                    new Cell[3] { new Cell { Value = new Player("Player1", true) }, new Cell { Value = new Player("Player1", true) }, new Cell { Value = new Player("Player1", true) } },
                    new Cell[3] { new Cell { Value = new Player("Player1", true) }, new Cell { Value = new Player("Player1", true) }, new Cell { Value = new Player("Player1", true) } },
                    new Cell[3] { new Cell { Value = new Player("Player1", true) }, new Cell { Value = new Player("Player1", true) }, new Cell { Value = new Player("Player1", true) } }
                }
            };
            var game = new Game
            {
                Boards = new Board[3][]
                {
                    new Board[3] { fullBoard, new Board(), new Board() },
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
            var rule = new BoardDoneRule();

            // Act
            var result = rule.IsMoveValid(game, move);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsMoveValid_ShouldThrowArgumentException_WhenBoardIsInvalid()
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
                BoardRow = 3, // Invalid row
                BoardColumn = 0,
                CellRow = 0,
                CellColumn = 0,
                Player = true
            };
            var rule = new BoardDoneRule();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => rule.IsMoveValid(game, move));
        }
    }
}

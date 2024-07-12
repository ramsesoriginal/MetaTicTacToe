using MetaTicTacToe.Models;
using MetaTicTacToe.Models.Converter;
using System.Text.Json;
using Xunit;

namespace MetaTicTacToe.Tests.Models.Converter
{
    public class CellJsonConverterTests
    {
        [Theory]
        [InlineData("X", "Player1", true)]
        [InlineData("O", "Player2", false)]
        [InlineData(" ", null, null)]
        public void Read_ShouldDeserializeCellCorrectly(string input, string expectedName, bool? expectedSymbol)
        {
            // Arrange
            var json = $"\"{input}\"";
            var options = new JsonSerializerOptions
            {
                Converters = { new CellJsonConverter() }
            };

            // Act
            var cell = JsonSerializer.Deserialize<Cell>(json, options);

            // Assert
            if (expectedName == null)
            {
                Assert.Null(cell.Value);
            }
            else
            {
                Assert.NotNull(cell.Value);
                Assert.Equal(expectedName, cell.Value.Name);
                Assert.Equal(expectedSymbol, cell.Value.Symbol);
            }
        }

        [Theory]
        [InlineData("Player1", true, "X")]
        [InlineData("Player2", false, "O")]
        [InlineData(null, null, " ")]
        public void Write_ShouldSerializeCellCorrectly(string name, bool? symbol, string expectedOutput)
        {
            // Arrange
            var player = name != null ? new Player(name, symbol.Value) : null;
            var cell = new Cell { Value = player };
            var options = new JsonSerializerOptions
            {
                Converters = { new CellJsonConverter() }
            };

            // Act
            var json = JsonSerializer.Serialize(cell, options);

            // Assert
            Assert.Equal($"\"{expectedOutput}\"", json);
        }
    }
}

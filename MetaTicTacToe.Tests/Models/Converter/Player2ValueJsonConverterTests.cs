using MetaTicTacToe.Models;
using MetaTicTacToe.Models.Converter;
using System.Text.Json;
using Xunit;

namespace MetaTicTacToe.Tests.Models.Converter
{
    public class Player2ValueJsonConverterTests
    {
        [Theory]
        [InlineData("X", "X", true)]
        [InlineData("O", "O", false)]
        [InlineData("", null, null)]
        public void Read_ShouldDeserializePlayerCorrectly(string input, string expectedName, bool? expectedSymbol)
        {
            // Arrange
            var json = $"\"{input}\"";
            var options = new JsonSerializerOptions
            {
                Converters = { new Player2ValueJsonConverter() }
            };

            // Act
            var player = JsonSerializer.Deserialize<Player>(json, options);

            // Assert
            if (expectedName == null)
            {
                Assert.Equal("", player.Name);
            }
            else
            {
                Assert.NotNull(player);
                Assert.Equal(expectedName, player.Name);
                Assert.Equal(expectedSymbol, player.Symbol);
            }
        }

        [Theory]
        [InlineData("Player1", true, "X")]
        [InlineData("Player2", false, "O")]
        public void Write_ShouldSerializePlayerCorrectly(string name, bool? symbol, string expectedOutput)
        {
            // Arrange
            var player = name != null ? new Player(name, symbol.Value) : null;
            var options = new JsonSerializerOptions
            {
                Converters = { new Player2ValueJsonConverter() }
            };

            // Act
            var json = JsonSerializer.Serialize(player, options);

            // Assert
            Assert.Equal($"\"{expectedOutput}\"", json);
        }
    }
}

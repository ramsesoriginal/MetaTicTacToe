using MetaTicTacToe.Models;
using MetaTicTacToe.Models.Converter;
using System.Text.Json;
using Xunit;

namespace MetaTicTacToe.Tests.Models.Converter
{
    public class Player2NameJsonConverterTests
    {
        [Theory]
        [InlineData("Player1", "Player1")]
        [InlineData("", null)]
        public void Read_ShouldDeserializePlayerCorrectly(string input, string expectedName)
        {
            // Arrange
            var json = $"\"{input}\"";
            var options = new JsonSerializerOptions
            {
                Converters = { new Player2NameJsonConverter() }
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
            }
        }

        [Theory]
        [InlineData("Player1", "Player1")]
        [InlineData("", "")]
        public void Write_ShouldSerializePlayerCorrectly(string name, string expectedOutput)
        {
            // Arrange
            var player = name != null ? new Player(name, true) : null;
            var options = new JsonSerializerOptions
            {
                Converters = { new Player2NameJsonConverter() }
            };

            // Act
            var json = JsonSerializer.Serialize(player, options);

            // Assert
            Assert.Equal($"\"{expectedOutput}\"", json);
        }
    }
}

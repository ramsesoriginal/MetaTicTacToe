using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MetaTicTacToe.Models;


namespace MetaTicTacToe.Models.Converter
{
    public class CellJsonConverter : JsonConverter<Cell>
    {
        public override Cell Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string stringValue = reader.GetString();
            if (stringValue == null) return null;

            // You need a way to parse the string back to a Player object if necessary.
            // For this example, let's assume X and O for player symbols.
            Player? player = stringValue == "X" ? new Player("Player1", true) : stringValue == "O" ? new Player("Player2", false) : null;
            return new Cell { Value = player };
        }

        public override void Write(Utf8JsonWriter writer, Cell value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
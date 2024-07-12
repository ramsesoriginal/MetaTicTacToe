using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using MetaTicTacToe.Models;


namespace MetaTicTacToe.Models.Converter { 
    public class Player2ValueJsonConverter : JsonConverter<Player?>
    {
        public override Player? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string stringValue = reader.GetString();
            if (stringValue == null) return null;

            // You need a way to parse the string back to a Player object if necessary.
            // For this example, let's assume X and O for player symbols.
            return new Player(stringValue, stringValue == "X");
        }

        public override void Write(Utf8JsonWriter writer, Player? value, JsonSerializerOptions options)
        {
            if (value != null)
            {
                writer.WriteStringValue(value.ToString());
            }
            else
            {
                writer.WriteStringValue(" ");
            }
        }
    }
}
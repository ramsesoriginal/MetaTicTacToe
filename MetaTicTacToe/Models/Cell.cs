using MetaTicTacToe.Models.Converter;
using System.Text.Json.Serialization;

namespace MetaTicTacToe.Models
{
    [JsonConverter(typeof(CellJsonConverter))]
    public class Cell : IWinner
    {
        [JsonConverter(typeof(Player2ValueJsonConverter))]
        public Player? Value { get; set; } = null;

        // Overload the equality operator
        public static bool operator ==(Cell c1, Cell c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;
            return c1.Value == c2.Value;
        }

        // Overload the inequality operator
        public static bool operator !=(Cell c1, Cell c2)
        {
            return !(c1 == c2);
        }

        // Override Equals and GetHashCode
        public override bool Equals(object obj)
        {
            if (obj is Cell other)
            {
                return Value == other.Value;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Value != null ?  Value.GetHashCode() : 0;
        }

        public override string ToString()
        {
            return Value != null ? (Value.Symbol ? "X" : "O") : " ";
        }

        [JsonIgnore]
        public bool Empty => Value == null;
        [JsonIgnore]
        public bool Filled => !Empty;
        [JsonIgnore]
        public Player? Winner => Value;
    }
}

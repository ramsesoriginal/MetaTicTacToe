using MetaTicTacToe.Models.Converter;
using System.Text.Json.Serialization;

namespace MetaTicTacToe.Models
{
    /// <summary>
    /// Represents a cell in the Meta Tic Tac Toe game.
    /// </summary>
    [JsonConverter(typeof(CellJsonConverter))]
    public class Cell : IWinner
    {
        /// <summary>
        /// Gets or sets the player occupying the cell.
        /// </summary>
        [JsonConverter(typeof(Player2ValueJsonConverter))]
        public Player? Value { get; set; } = null;

        /// <summary>
        /// Overloads the equality operator to compare two cells.
        /// </summary>
        /// <param name="c1">The first cell to compare.</param>
        /// <param name="c2">The second cell to compare.</param>
        /// <returns>True if the cells are equal; otherwise, false.</returns>
        public static bool operator ==(Cell c1, Cell c2)
        {
            if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
                return true;
            if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
                return false;
            return c1.Value == c2.Value;
        }

        /// <summary>
        /// Overloads the inequality operator to compare two cells.
        /// </summary>
        /// <param name="c1">The first cell to compare.</param>
        /// <param name="c2">The second cell to compare.</param>
        /// <returns>True if the cells are not equal; otherwise, false.</returns>
        public static bool operator !=(Cell c1, Cell c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current cell.
        /// </summary>
        /// <param name="obj">The object to compare with the current cell.</param>
        /// <returns>True if the specified object is equal to the current cell; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Cell other)
            {
                return Value == other.Value;
            }
            return false;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current cell.</returns>
        public override int GetHashCode()
        {
            return Value != null ? Value.GetHashCode() : 0;
        }

        /// <summary>
        /// Returns a string that represents the current cell.
        /// </summary>
        /// <returns>"X" if the player's symbol is true, "O" if the player's symbol is false, or " " if the cell is empty.</returns>
        public override string ToString()
        {
            return Value != null ? (Value.Symbol ? "X" : "O") : " ";
        }

        /// <summary>
        /// Gets a value indicating whether the cell is empty.
        /// </summary>
        [JsonIgnore]
        public bool Empty => Value == null;

        /// <summary>
        /// Gets a value indicating whether the cell is filled.
        /// </summary>
        [JsonIgnore]
        public bool Filled => !Empty;

        /// <summary>
        /// Gets the player occupying the cell, indicating the winner.
        /// </summary>
        [JsonIgnore]
        public Player? Winner => Value;
    }
}

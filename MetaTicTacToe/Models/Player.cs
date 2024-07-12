using System;

namespace MetaTicTacToe.Models
{
    /// <summary>
    /// Represents a player in the Meta Tic Tac Toe game.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when the name is null.</exception>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the symbol of the player. True for one player, false for the other.
        /// </summary>
        public bool Symbol { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class with the specified name and symbol.
        /// </summary>
        /// <param name="name">The name of the player.</param>
        /// <param name="symbol">The symbol of the player. True for one player, false for the other.</param>
        /// <exception cref="ArgumentNullException">Thrown when the name is null.</exception>
        public Player(string name, bool symbol)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name), "name can't be null");
            Name = name;
            Symbol = symbol;
        }

        /// <summary>
        /// Returns a string that represents the current player.
        /// </summary>
        /// <returns>"X" if the player's symbol is true, otherwise "O".</returns>
        public override string ToString()
        {
            return Symbol ? "X" : "O";
        }
    }
}

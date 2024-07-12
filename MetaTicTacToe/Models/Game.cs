using MetaTicTacToe.Models.Converter;
using System.Text.Json.Serialization;

namespace MetaTicTacToe.Models
{
    /// <summary>
    /// Represents a game of Meta Tic Tac Toe.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the identifier of the game.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the boards in the game. Each game contains a 3x3 grid of boards.
        /// </summary>
        public Board[][] Boards { get; set; } = new Board[3][];

        /// <summary>
        /// Gets or sets the current player of the game.
        /// </summary>
        [JsonConverter(typeof(Player2NameJsonConverter))]
        public Player CurrentPlayer { get; set; }

        /// <summary>
        /// Gets or sets the winner of the game, if any.
        /// </summary>
        [JsonConverter(typeof(Player2NameJsonConverter))]
        public Player? Winner { get; set; } = null;

        /// <summary>
        /// Gets or sets the first player in the game.
        /// </summary>
        public Player Player1 { get; set; }

        /// <summary>
        /// Gets or sets the second player in the game.
        /// </summary>
        public Player Player2 { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class and sets up the 3x3 grid of boards.
        /// </summary>
        public Game()
        {
            for (int i = 0; i < 3; i++)
            {
                Boards[i] = new Board[3];
                for (int j = 0; j < 3; j++)
                {
                    Boards[i][j] = new Board { Id = i * 3 + j };
                }
            }
        }
    }
}

namespace MetaTicTacToe.Models
{
    /// <summary>
    /// Represents a move in the Meta Tic Tac Toe game.
    /// </summary>
    public class Move
    {
        /// <summary>
        /// Gets or sets the ID of the game in which the move is made.
        /// </summary>
        public required int GameId { get; set; }

        /// <summary>
        /// Gets or sets the row of the board where the move is made.
        /// </summary>
        public required int BoardRow { get; set; }

        /// <summary>
        /// Gets or sets the column of the board where the move is made.
        /// </summary>
        public required int BoardColumn { get; set; }

        /// <summary>
        /// Gets or sets the row of the cell where the move is made.
        /// </summary>
        public required int CellRow { get; set; }

        /// <summary>
        /// Gets or sets the column of the cell where the move is made.
        /// </summary>
        public required int CellColumn { get; set; }

        /// <summary>
        /// Gets or sets the player making the move. True for one player, false for the other.
        /// </summary>
        public required bool Player { get; set; }
    }
}

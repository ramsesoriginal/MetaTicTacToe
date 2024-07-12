namespace MetaTicTacToe.Models
{
    /// <summary>
    /// Defines the contract for a rule that validates a move in the Meta Tic Tac Toe game.
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Determines whether a move is valid according to the rule.
        /// </summary>
        /// <param name="game">The game instance to validate the move against.</param>
        /// <param name="move">The move to validate.</param>
        /// <returns><c>true</c> if the move is valid; otherwise, <c>false</c>.</returns>
        bool IsMoveValid(Game game, Move move);
    }
}

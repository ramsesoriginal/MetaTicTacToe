using MetaTicTacToe.Models;

namespace MetaTicTacToe.Services
{
    /// <summary>
    /// Service interface for validating moves in the Meta Tic Tac Toe game according to various rules.
    /// </summary>
    public interface IRuleService
    {
        /// <summary>
        /// Validates a move by checking it against all defined rules.
        /// </summary>
        /// <param name="game">The game instance to validate the move against.</param>
        /// <param name="move">The move to validate.</param>
        /// <returns><c>true</c> if the move is valid according to all rules; otherwise, <c>false</c>.</returns>
        bool ValidateMove(Game game, Move move);
    }
}

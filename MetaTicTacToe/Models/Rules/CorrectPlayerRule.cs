namespace MetaTicTacToe.Models.Rules
{
    /// <summary>
    /// Rule that validates if the correct player is making the move in the Meta Tic Tac Toe game.
    /// </summary>
    public class CorrectPlayerRule : IRule
    {
        /// <summary>
        /// Determines whether a move is valid based on the current player's turn.
        /// </summary>
        /// <param name="game">The game instance to validate the move against.</param>
        /// <param name="move">The move to validate.</param>
        /// <returns><c>true</c> if the move is valid and it is the current player's turn; otherwise, <c>false</c>.</returns>
        public bool IsMoveValid(Game game, Move move)
        {
            if (move.Player != game.CurrentPlayer.Symbol)
            {
                return false;
            }
            return true;
        }
    }
}

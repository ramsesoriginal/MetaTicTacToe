namespace MetaTicTacToe.Models.Rules
{
    /// <summary>
    /// Rule that validates if the board specified by move is already done
    /// </summary>
    public class BoardDoneRule : IRule
    {
        /// <summary>
        /// Determines whether a move is valid based on the target board
        /// </summary>
        /// <param name="game">The game instance to validate the move against.</param>
        /// <param name="move">The move to validate.</param>
        /// <returns><c>true</c> if the move targets a valid board; otherwise, <c>false</c>.</returns>
        public bool IsMoveValid(Game game, Move move)
        {
            Board board = null;
            try
            {
                board = game.Boards[move.BoardRow][move.BoardColumn];

                if (!board.IsFull)
                {
                    return true;
                }
            }
            catch
            {
                throw new ArgumentException("Invalid board");
            }
            return false;
        }
    }
}

namespace MetaTicTacToe.Models.Rules
{
    /// <summary>
    /// Rule that validates if the board is the correct one as specified by the last move
    /// </summary>
    public class RecursiveBoardRule : IRule
    {
        /// <summary>
        /// Determines whether a move is valid based on the last move
        /// </summary>
        /// <param name="game">The game instance to validate the move against.</param>
        /// <param name="move">The move to validate.</param>
        /// <returns><c>true</c> if the move targets a valid board; otherwise, <c>false</c>.</returns>
        public bool IsMoveValid(Game game, Move move)
        {
            var old_move = game.LastMove;
            if (old_move == null)
            {
                return true;
            }
            try
            {
                var target_board = game.Boards[old_move.CellRow][old_move.CellColumn];
                var board = game.Boards[move.BoardRow][move.BoardColumn];

                if (target_board.IsFull)
                {
                    return true;
                }

                if (target_board == board)
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

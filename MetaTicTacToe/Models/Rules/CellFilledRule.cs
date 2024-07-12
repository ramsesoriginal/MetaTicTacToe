namespace MetaTicTacToe.Models.Rules
{
    /// <summary>
    /// Rule that validates if the cell specified by move is already filled
    /// </summary>
    public class CellFilledRule : IRule
    {
        /// <summary>
        /// Determines whether a move is valid based on the target cell
        /// </summary>
        /// <param name="game">The game instance to validate the move against.</param>
        /// <param name="move">The move to validate.</param>
        /// <returns><c>true</c> if the move targets a valid cell; otherwise, <c>false</c>.</returns>
        public bool IsMoveValid(Game game, Move move)
        {
            try
            {
                var board = game.Boards[move.BoardRow][move.BoardColumn];
                if (board.Cells[move.CellRow][move.CellColumn].Filled)
                {
                    return false;
                }
            }
            catch
            {
                throw new ArgumentException("Invalid cell");
            }
            return true;
        }
    }
}

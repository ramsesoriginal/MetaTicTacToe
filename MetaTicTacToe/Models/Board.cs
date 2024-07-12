namespace MetaTicTacToe.Models
{
    /// <summary>
    /// Represents a board in the Meta Tic Tac Toe game.
    /// </summary>
    public class Board : IWinner
    {
        /// <summary>
        /// Gets or sets the identifier of the board.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the cells of the board. Each board contains a 3x3 grid of cells.
        /// </summary>
        public Cell[][] Cells { get; set; } = new Cell[3][];

        /// <summary>
        /// Gets or sets the player who has won on this board, if any.
        /// </summary>
        public Player? Winner { get; set; } = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class and sets up the 3x3 grid of cells.
        /// </summary>
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                Cells[i] = new Cell[3];
                for (int j = 0; j < 3; j++)
                {
                    Cells[i][j] = new Cell();
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the board is full. A board is full if all cells are filled and there is no winner.
        /// </summary>
        public bool IsFull
        {
            get
            {
                if (Winner != null)
                    return false;
                foreach (var row in Cells)
                {
                    foreach (var cell in row)
                        if (cell.Empty)
                        {
                            return false;
                        }
                }
                return true;
            }
        }
    }
}

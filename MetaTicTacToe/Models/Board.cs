namespace MetaTicTacToe.Models
{
    public class Board: IWinner
    {
        public int Id { get; set; }
        public Cell[][] Cells { get; set; } = new Cell[3][];
        public Player? Winner { get; set; } = null;
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

        public bool IsFull
        {
            get
            {
                if (Winner != null)
                    return false;
                foreach (var row in Cells)
                {
                    foreach(var cell in row)
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

namespace MetaTicTacToe.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string[][] Cells { get; set; } = new string[3][];
        public string Winner { get; set; }
        public Board()
        {
            for (int i = 0; i < 3; i++)
            {
                Cells[i] = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    Cells[i][j] = "";
                }
            }
        }
        public bool IsFull
        {
            get
            {
                foreach (var row in Cells)
                {
                    foreach(var cell in row)
                        if (string.IsNullOrEmpty(cell))
                        {
                            return false;
                        }
                }
                return true;
            }
        }
    }
}

namespace MetaTicTacToe.Models
{
    public class Board
    {
        public int Id { get; set; }
        public string[,] Cells { get; set; } = new string[3, 3];
        public string Winner { get; set; }
    }
}

namespace MetaTicTacToe.Models
{
    public class Move
    {
        public int GameId { get; set; }
        public int BoardRow { get; set; }
        public int BoardColumn { get; set; }
        public int CellRow { get; set; }
        public int CellColumn { get; set; }
        public string Player { get; set; }
    }
}

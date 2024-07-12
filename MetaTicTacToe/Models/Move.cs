namespace MetaTicTacToe.Models
{
    public class Move
    {
        public required int GameId { get; set; }
        public required int BoardRow { get; set; }
        public required int BoardColumn { get; set; }
        public required int CellRow { get; set; }
        public required int CellColumn { get; set; }
        public required bool Player { get; set; }
    }
}

namespace MetaTicTacToe.Models
{
    public class Game
    {
        public int Id { get; set; }
        public Board[][] Boards { get; set; }
        public string CurrentPlayer { get; set; }
        public string Winner { get; set; }
    }
}

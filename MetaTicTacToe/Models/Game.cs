namespace MetaTicTacToe.Models
{
    public class Game
    {
        public int Id { get; set; }
        public Board[][] Boards { get; set; } = new Board[3][];
        public string CurrentPlayer { get; set; }
        public string Winner { get; set; }

        public Game()
        {
            for (int i = 0; i < 3; i++)
            {
                Boards[i] = new Board[3];
                for (int j = 0; j < 3; j++)
                {
                    Boards[i][j] = new Board { Id = i * 3 + j };
                }
            }
        }
    }
}

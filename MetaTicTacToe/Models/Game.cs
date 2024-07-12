using MetaTicTacToe.Models.Converter;
using System.Text.Json.Serialization;

namespace MetaTicTacToe.Models
{
    public class Game
    {
        public int Id { get; set; }
        public Board[][] Boards { get; set; } = new Board[3][];

        [JsonConverter(typeof(Player2NameJsonConverter))]
        public Player CurrentPlayer { get; set; }

        [JsonConverter(typeof(Player2NameJsonConverter))]
        public Player? Winner { get; set; } = null;
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

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

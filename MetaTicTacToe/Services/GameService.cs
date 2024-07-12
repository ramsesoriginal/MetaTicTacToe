using MetaTicTacToe.Models;
using MetaTicTacToe.Repositories;
using System;

namespace MetaTicTacToe.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;

        public GameService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public Game StartGame()
        {
            var game = new Game
            {
                Boards = new Board[3][]
                {
                    new Board[3],
                    new Board[3],
                    new Board[3]
                },
                CurrentPlayer = "Player1"
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    game.Boards[i][j] = new Board();
                }
            }

            return _gameRepository.AddGame(game);
        }

        public Game MakeMove(Move move)
        {
            var game = _gameRepository.GetGame(move.GameId);

            if (game == null)
            {
                throw new ArgumentException("Invalid game ID");
            }

            var board = game.Boards[move.BoardRow][move.BoardColumn];
            board.Cells[move.CellRow, move.CellColumn] = move.Player;
            game.CurrentPlayer = game.CurrentPlayer == "Player1" ? "Player2" : "Player1";

            _gameRepository.UpdateGame(game);

            return game;
        }

        public Game GetGameStatus(int id)
        {
            return _gameRepository.GetGame(id);
        }
    }
}

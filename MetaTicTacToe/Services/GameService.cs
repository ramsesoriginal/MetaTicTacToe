using MetaTicTacToe.Models;
using MetaTicTacToe.Repositories;
using System;
using System.Reflection;

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
            var p1 = new Player("Player1", true);
            var p2 = new Player("Player2", false);
            var game = new Game
            {
                Player1 = p1,
                Player2 = p2,
                CurrentPlayer = p1
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
            if (board == null || !(board.Winner==null))
            {
                throw new ArgumentException("Invalid board");
            }
            if (board.Cells[move.CellRow][move.CellColumn].Filled)
            {
                throw new ArgumentException("Cell already occupied");
            }
            if (move.Player != game.CurrentPlayer.Symbol)
            {
                throw new ArgumentException("Wrong Player");
            }
            board.Cells[move.CellRow][move.CellColumn].Value = game.CurrentPlayer;
            board.Winner = CheckWinner(board.Cells);
            game.Winner = CheckWinner(game.Boards);

            game.CurrentPlayer = game.CurrentPlayer == game.Player1 ? game.Player2 : game.Player1;

            _gameRepository.UpdateGame(game);

            return game;
        }

        public Game GetGameStatus(int id)
        {
            return _gameRepository.GetGame(id);
        }

        private Player? CheckWinner(IWinner[][] boards)
        {
            for (int i = 0; i < 3; i++)
            {
                if (boards[i][0].Winner != null && boards[i][0].Winner == boards[i][1].Winner && boards[i][1].Winner == boards[i][2].Winner)
                {
                    return boards[i][0].Winner;
                }

                if (boards[0][i].Winner != null && boards[0][i].Winner == boards[1][i].Winner && boards[1][i].Winner == boards[2][i].Winner)
                {
                    return boards[0][i].Winner;
                }
            }

            if (boards[0][0].Winner != null && boards[0][0].Winner == boards[1][1].Winner && boards[1][1].Winner == boards[2][2].Winner)
            {
                return boards[0][0].Winner;
            }

            if (boards[0][2].Winner != null && boards[0][2].Winner == boards[1][1].Winner && boards[1][1].Winner == boards[2][0].Winner)
            {
                return boards[0][2].Winner;
            }

            return null;
        }
    }
}

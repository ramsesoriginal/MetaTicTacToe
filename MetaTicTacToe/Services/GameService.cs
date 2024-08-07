using MetaTicTacToe.Models;
using MetaTicTacToe.Repositories;
using System;
using System.Reflection;

namespace MetaTicTacToe.Services
{
    /// <summary>
    /// Service for managing the logic of Meta Tic Tac Toe games.
    /// </summary>
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IRuleService _ruleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameService"/> class.
        /// </summary>
        /// <param name="gameRepository">The game repository to use for storing and retrieving games.</param>
        public GameService(IGameRepository gameRepository, IRuleService ruleService)
        {
            _gameRepository = gameRepository;
            _ruleService = ruleService;
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        /// <returns>The newly started game.</returns>
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

        /// <summary>
        /// Makes a move in the specified game.
        /// </summary>
        /// <param name="move">The move to make.</param>
        /// <returns>The updated game after the move is made.</returns>
        /// <exception cref="ArgumentException">Thrown when the game ID, board, cell, or player is invalid.</exception>
        public Game MakeMove(Move move)
        {
            var game = _gameRepository.GetGame(move.GameId);

            if (game == null)
            {
                throw new ArgumentException("Invalid game ID");
            }

            if (!_ruleService.ValidateMove(game, move))
            {
                throw new ArgumentException("Invalid move");
            }

            Board board = game.Boards[move.BoardRow][move.BoardColumn];
            
            board.Cells[move.CellRow][move.CellColumn].Value = game.CurrentPlayer;
            board.Winner = CheckWinner(board.Cells);
            game.Winner = CheckWinner(game.Boards);

            game.CurrentPlayer = game.CurrentPlayer == game.Player1 ? game.Player2 : game.Player1;
            game.LastMove = move;

            _gameRepository.UpdateGame(game);

            return game;
        }

        /// <summary>
        /// Gets the status of a game by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the game.</param>
        /// <returns>The game with the specified identifier, or null if no game is found.</returns>
        public Game GetGameStatus(int id)
        {
            return _gameRepository.GetGame(id);
        }

        /// <summary>
        /// Retrieves all games.
        /// </summary>
        /// <returns>An enumerable collection of all games.</returns>
        public IEnumerable<Game> GetAllGames()
        {
            return _gameRepository.GetAllGames();
        }

        /// <summary>
        /// Retrieves only the open games (games with no winner).
        /// </summary>
        /// <returns>An enumerable collection of open games.</returns>
        public IEnumerable<Game> GetOpenGames()
        {
            return _gameRepository.GetOpenGames();
        }

        /// <summary>
        /// Retrieves only the closed games (games with a winner).
        /// </summary>
        /// <returns>An enumerable collection of closed games.</returns>
        public IEnumerable<Game> GetClosedGames()
        {
            return _gameRepository.GetClosedGames();
        }

        /// <summary>
        /// Deletes a game by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the game to delete.</param>
        public void DeleteGame(int id)
        {
            _gameRepository.DeleteGame(id);
        }

        /// <summary>
        /// Checks for a winner in a set of boards or cells.
        /// </summary>
        /// <param name="boards">The set of boards or cells to check.</param>
        /// <returns>The player who won, or null if there is no winner.</returns>
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

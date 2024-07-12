using MetaTicTacToe.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetaTicTacToe.Repositories
{
    /// <summary>
    /// Repository for managing games of Meta Tic Tac Toe.
    /// </summary>
    public class GameRepository : IGameRepository
    {
        private readonly List<Game> _games = new();

        /// <summary>
        /// Retrieves a game by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the game to retrieve.</param>
        /// <returns>The game with the specified identifier, or null if no game is found.</returns>
        public Game GetGame(int id) => _games.FirstOrDefault(g => g.Id == id);

        /// <summary>
        /// Retrieves all games.
        /// </summary>
        /// <returns>An enumerable collection of all games.</returns>
        public IEnumerable<Game> GetAllGames() => _games;


        /// <summary>
        /// Retrieves all open games.
        /// </summary>
        /// <returns>An enumerable collection of all open games.</returns>
        public IEnumerable<Game> GetOpenGames() => _games.Where(g => g.Winner == null);

        /// <summary>
        /// Retrieves all closed games.
        /// </summary>
        /// <returns>An enumerable collection of all closed games.</returns>
        public IEnumerable<Game> GetClosedGames() => _games.Where(g => g.Winner != null);


        /// <summary>
        /// Adds a new game to the repository.
        /// </summary>
        /// <param name="game">The game to add.</param>
        /// <returns>The added game with its identifier set.</returns>
        public Game AddGame(Game game)
        {
            game.Id = _games.Count + 1;
            _games.Add(game);
            return game;
        }

        /// <summary>
        /// Updates an existing game in the repository.
        /// </summary>
        /// <param name="game">The game with updated information.</param>
        public void UpdateGame(Game game)
        {
            var existingGame = GetGame(game.Id);
            if (existingGame != null)
            {
                _games.Remove(existingGame);
                _games.Add(game);
            }
        }

        /// <summary>
        /// Deletes a game by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the game to delete.</param>
        public void DeleteGame(int id)
        {
            var game = GetGame(id);
            if (game != null)
            {
                _games.Remove(game);
            }
        }
    }
}

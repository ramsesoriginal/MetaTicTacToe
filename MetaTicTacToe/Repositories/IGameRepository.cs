using MetaTicTacToe.Models;
using System.Collections.Generic;

namespace MetaTicTacToe.Repositories
{
    /// <summary>
    /// Interface for the repository that manages games of Meta Tic Tac Toe.
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Retrieves a game by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the game to retrieve.</param>
        /// <returns>The game with the specified identifier, or null if no game is found.</returns>
        Game GetGame(int id);

        /// <summary>
        /// Retrieves all games.
        /// </summary>
        /// <returns>An enumerable collection of all games.</returns>
        IEnumerable<Game> GetAllGames();

        /// <summary>
        /// Retrieves all open games.
        /// </summary>
        /// <returns>An enumerable collection of all open games.</returns>
        IEnumerable<Game> GetOpenGames();

        /// <summary>
        /// Retrieves all closed games.
        /// </summary>
        /// <returns>An enumerable collection of all closed games.</returns>
        IEnumerable<Game> GetClosedGames();

        /// <summary>
        /// Adds a new game to the repository.
        /// </summary>
        /// <param name="game">The game to add.</param>
        /// <returns>The added game with its identifier set.</returns>
        Game AddGame(Game game);

        /// <summary>
        /// Updates an existing game in the repository.
        /// </summary>
        /// <param name="game">The game with updated information.</param>
        void UpdateGame(Game game);
    }
}

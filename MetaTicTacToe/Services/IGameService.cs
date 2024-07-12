using MetaTicTacToe.Models;

namespace MetaTicTacToe.Services
{
    /// <summary>
    /// Interface for the service that manages the logic for Meta Tic Tac Toe games.
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Starts a new game.
        /// </summary>
        /// <returns>The newly started game.</returns>
        Game StartGame();

        /// <summary>
        /// Makes a move in the specified game.
        /// </summary>
        /// <param name="move">The move to make.</param>
        /// <returns>The updated game after the move is made.</returns>
        Game MakeMove(Move move);

        /// <summary>
        /// Gets the status of a game by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the game.</param>
        /// <returns>The game with the specified identifier, or null if no game is found.</returns>
        Game GetGameStatus(int id);

        /// <summary>
        /// Retrieves all games.
        /// </summary>
        /// <returns>An enumerable collection of all games.</returns>
        IEnumerable<Game> GetAllGames();

        /// <summary>
        /// Retrieves only the open games (games with no winner).
        /// </summary>
        /// <returns>An enumerable collection of open games.</returns>
        IEnumerable<Game> GetOpenGames();

        /// <summary>
        /// Retrieves only the closed games (games with a winner).
        /// </summary>
        /// <returns>An enumerable collection of closed games.</returns>
        IEnumerable<Game> GetClosedGames();

        /// <summary>
        /// Deletes a game by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the game to delete.</param>
        void DeleteGame(int id);
    }
}

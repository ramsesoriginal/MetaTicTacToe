using MetaTicTacToe.Models;
using MetaTicTacToe.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetaTicTacToe.Controllers
{
    /// <summary>
    /// API controller for managing Meta Tic Tac Toe games.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameController"/> class.
        /// </summary>
        /// <param name="gameService">The game service to use for managing games.</param>
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        /// <summary>
        /// Starts a new game, assigning it a new ID and initializing the board.
        /// </summary>
        /// <returns>The newly started game.</returns>
        [HttpPost("start")]
        public ActionResult<Game> StartGame()
        {
            var game = _gameService.StartGame();
            return Ok(game);
        }

        /// <summary>
        /// Makes a move in the specified game, and validates if the move is allowed and correct.
        /// </summary>
        /// <param name="move">The move to make.</param>
        /// <returns>The updated game after the move is made.</returns>
        [HttpPost("move")]
        public ActionResult<Game> MakeMove([FromBody] Move move)
        {
            var game = _gameService.MakeMove(move);
            return Ok(game);
        }

        /// <summary>
        /// Gets the status of a game by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the game.</param>
        /// <returns>The game with the specified identifier.</returns>
        [HttpGet("{id}/status")]
        public ActionResult<Game> GetGameStatus(int id)
        {
            var game = _gameService.GetGameStatus(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }


        /// <summary>
        /// Retrieves all games.
        /// </summary>
        /// <returns>An enumerable collection of all games.</returns>
        [HttpGet("all")]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
            var games = _gameService.GetAllGames();
            return Ok(games);
        }

        /// <summary>
        /// Retrieves only the open games (games with no winner).
        /// </summary>
        /// <returns>An enumerable collection of open games.</returns>
        [HttpGet("open")]
        public ActionResult<IEnumerable<Game>> GetOpenGames()
        {
            var games = _gameService.GetOpenGames();
            return Ok(games);
        }

        /// <summary>
        /// Retrieves only the closed games (games with a winner).
        /// </summary>
        /// <returns>An enumerable collection of closed games.</returns>
        [HttpGet("closed")]
        public ActionResult<IEnumerable<Game>> GetClosedGames()
        {
            var games = _gameService.GetClosedGames();
            return Ok(games);
        }

        /// <summary>
        /// Deletes a game by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the game to delete.</param>
        /// <returns>No content if the deletion is successful.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            _gameService.DeleteGame(id);
            return NoContent();
        }
    }
}

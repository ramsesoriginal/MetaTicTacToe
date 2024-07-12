using MetaTicTacToe.Models;
using MetaTicTacToe.Services;
using Microsoft.AspNetCore.Mvc;

namespace MetaTicTacToe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost("start")]
        public ActionResult<Game> StartGame()
        {
            var game = _gameService.StartGame();
            return Ok(game);
        }

        [HttpPost("move")]
        public ActionResult<Game> MakeMove([FromBody] Move move)
        {
            var game = _gameService.MakeMove(move);
            return Ok(game);
        }

        [HttpGet("{id}/status")]
        public ActionResult<Game> GetGameStatus(int id)
        {
            var game = _gameService.GetGameStatus(id);
            return Ok(game);
        }
    }
}

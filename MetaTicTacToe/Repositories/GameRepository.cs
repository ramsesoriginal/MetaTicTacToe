using MetaTicTacToe.Models;
using System.Collections.Generic;
using System.Linq;

namespace MetaTicTacToe.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly List<Game> _games = new();

        public Game GetGame(int id) => _games.FirstOrDefault(g => g.Id == id);

        public IEnumerable<Game> GetAllGames() => _games;

        public Game AddGame(Game game)
        {
            game.Id = _games.Count + 1;
            _games.Add(game);
            return game;
        }

        public void UpdateGame(Game game)
        {
            var existingGame = GetGame(game.Id);
            if (existingGame != null)
            {
                _games.Remove(existingGame);
                _games.Add(game);
            }
        }
    }
}

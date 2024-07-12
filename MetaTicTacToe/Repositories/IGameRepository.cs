using MetaTicTacToe.Models;

namespace MetaTicTacToe.Repositories
{
    public interface IGameRepository
    {
        Game GetGame(int id);
        IEnumerable<Game> GetAllGames();
        Game AddGame(Game game);
        void UpdateGame(Game game);
    }
}

using MetaTicTacToe.Models;

namespace MetaTicTacToe.Services
{
    public interface IGameService
    {
        Game StartGame();
        Game MakeMove(Move move);
        Game GetGameStatus(int id);
    }
}

using System.Threading.Tasks;
using RockPaperScissors.Models;

namespace RockPaperScissors.Services
{
    public interface IGameSearchService
    {
        Task<GameSearchResult> SearchGame(GameSearch gameSearch);
    }
}
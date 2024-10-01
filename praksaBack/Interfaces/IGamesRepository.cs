using praksaBack.Models;

namespace praksaBack.Interfaces
{
    public interface IGamesRepository
    {
        Task<List<Game>> GetAllAsync();

        Task<Game?> GetByIdAsync(int id);

        Task<Game> CreateAsync(Game gameModel);
    }
}
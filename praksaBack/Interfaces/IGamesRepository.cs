using praksaBack.Models;

namespace praksaBack.Interfaces
{
    public interface IGamesRepository
    {
        Task<List<Game>> GetAllAsync();

        Task<Game?> GetByIdAsync(int id);

        Task<Game> CreateAsync(Game gameModel);

        Task<Game?> DeleteAsync(int id);

        Task<Game?> UpdateAsync(int id, Game gameModel);
    }
}
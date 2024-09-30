using praksaBack.Models;

namespace praksaBack.Interfaces
{
    public interface IGamesRepository
    {
        Task<List<Game>> GetAllAsync();
    }
}
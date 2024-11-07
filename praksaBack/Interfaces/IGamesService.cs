using praksaBack.Dtos.Category;
using praksaBack.Dtos.Game;
using praksaBack.Models;

namespace praksaBack.Interfaces
{
    public interface IGamesService
    {
        Task<List<GameDto>> GetAllAsync();

        Task<GameDto?> GetByIdAsync(int id);

        Task<GameDto> CreateAsync(CreateGameDto gameModel);

        Task<GameDto?> DeleteAsync(int id);

        Task<GameDto?> UpdateAsync(int id, UpdateGameRequestDto gameModel);

        // Nova metoda za pretragu igara
        Task<List<GameResponse>> SearchAsync(SearchRequest searchTerm);
    }
}
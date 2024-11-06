using praksaBack.Dtos.Category;
using praksaBack.Dtos.Game;

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
        Task<List<GameDto>> Search(string searchTerm);
    }
}
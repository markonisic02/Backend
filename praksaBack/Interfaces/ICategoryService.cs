using praksaBack.Dtos.Category;
using praksaBack.Dtos.Game;

namespace praksaBack.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync();

        Task<CategoryDto?> GetByIdAsync(int id);

        Task<CategoryDto> CreateAsync(CreateCategoryRequestDto categoryDto);

        Task<bool> DeleteAsync(int id);

        Task<CategoryDto?> UpdateAsync(int id, CategoryDto categoryDto);
    }
}
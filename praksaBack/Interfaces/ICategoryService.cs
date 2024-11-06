using praksaBack.Dtos.Category;
using praksaBack.Dtos.Game;

namespace praksaBack.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetByIdAsync(int id);

        Task<CategoryDto> CreateAsync(CreateCategoryRequestDto createCategoryRequestDto);
    }
}
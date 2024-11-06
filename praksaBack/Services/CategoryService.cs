using praksaBack.Dtos.Category;
using praksaBack.Interfaces;
using praksaBack.Mappers;

namespace praksaBack.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryRequestDto createCategoryRequestDto)
        {
            var newCategory = createCategoryRequestDto.ToCategoryFromCreateDto();
            await _categoryRepository.CreateAsync(newCategory);
            return newCategory.ToCategoryDto();
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Game not found");
            }
            return category.ToCategoryDto();
        }
    }
}
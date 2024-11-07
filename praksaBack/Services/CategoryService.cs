using praksaBack.Dtos.Category;
using praksaBack.Interfaces;
using praksaBack.Mappers;

namespace praksaBack.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGamesRepository _gamesRepository;

        public CategoryService(ICategoryRepository categoryRepository, IGamesRepository gamesRepository)
        {
            _categoryRepository = categoryRepository;
            _gamesRepository = gamesRepository;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryRequestDto createCategoryRequestDto)
        {
            var newCategory = createCategoryRequestDto.ToCategoryFromCreateDto();
            await _categoryRepository.CreateAsync(newCategory);
            return newCategory.ToCategoryDto();
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException("Game not found");
            }
            return category.ToCategoryDto();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => c.ToCategoryDto());
        }

        public async Task<bool> DeleteAsync(int id)
        {
            bool gameExist = (await _gamesRepository.GetAllAsync()).Any(g => g.CategoryId == id);
            if (gameExist)
            {
                throw new InvalidOperationException("Postoje igrice u ovoj kategoriji");
            }
            var category = await _categoryRepository.DeleteAsync(id);
            return category != null;
        }

        public async Task<CategoryDto?> UpdateAsync(int id, CategoryDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromUpdate();
            var updatedCategory = await _categoryRepository.UpdateAsync(id, categoryModel);
            return updatedCategory?.ToCategoryDto();
        }
    }
}
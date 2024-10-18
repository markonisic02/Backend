using praksaBack.Models;

namespace praksaBack.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();

        Task<Category?> GetByIdAsync(int id);

        Task<Category> CreateAsync(Category categoryModel);

        Task<bool> CategoryExists(int id);

        Task<Category?> DeleteAsync(int id);

        Task<Category?> UpdateAsync(int id, Category categoryModel);
    }
}
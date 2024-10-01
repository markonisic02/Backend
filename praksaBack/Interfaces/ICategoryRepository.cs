using praksaBack.Models;

namespace praksaBack.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();

        Task<Category> CreateAsync(Category categoryModel);

        Task<bool> CategoryExists(int id);
    }
}
using Microsoft.EntityFrameworkCore;
using praksaBack.Data;
using praksaBack.Interfaces;
using praksaBack.Models;

namespace praksaBack.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> CategoryExists(int id)
        {
            return _context.Categories.AnyAsync(c => c.Id == id);
        }

        public async Task<Category> CreateAsync(Category categoryModel)
        {
            await _context.Categories.AddAsync(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<Category?> DeleteAsync(int id)
        {
            var categoryModel = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (categoryModel == null)
            {
                return null;
            }
            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return categoryModel;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories = _context.Categories.Include(g => g.Games);
            return await categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.Include(c => c.Games).FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
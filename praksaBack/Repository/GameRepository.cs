using Microsoft.EntityFrameworkCore;
using praksaBack.Data;
using praksaBack.Interfaces;
using praksaBack.Models;

namespace praksaBack.Repository
{
    public class GameRepository : IGamesRepository
    {
        public readonly ApplicationDBContext _context;

        public GameRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Game> CreateAsync(Game gameModel)
        {
            await _context.Games.AddAsync(gameModel);
            await _context.SaveChangesAsync();
            return gameModel;
        }

        public async Task<Game?> DeleteAsync(int id)
        {
            var gameModel = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);

            if (gameModel == null)
            {
                return null;
            }
            _context.Games.Remove(gameModel);
            await _context.SaveChangesAsync();
            return gameModel;
        }

        public async Task<List<Game>> GetAllAsync()

        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetByIdAsync(int id)
        {
            return await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<List<Game>> SearchAsync(string searchTerm)
        {
            return await _context.Games
       .Where(g => g.Title.Contains(searchTerm) ||
                   g.Description.Contains(searchTerm) ||
                   g.ImageUrl.Contains(searchTerm)) // Dodajte i druge kriterijume pretrage ako je potrebno
       .ToListAsync();
        }

        public async Task<Game?> UpdateAsync(int id, Game gameModel)
        {
            var existingGame = await _context.Games.FindAsync(id);
            if (existingGame == null)
            {
                return null;
            }
            existingGame.Title = gameModel.Title;
            existingGame.Description = gameModel.Description;
            existingGame.ImageUrl = gameModel.ImageUrl;
            existingGame.CategoryId = gameModel.CategoryId;

            await _context.SaveChangesAsync();
            return existingGame;
        }
    }
}
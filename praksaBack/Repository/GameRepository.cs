using Azure.Core;
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

        public async Task<List<GameResponse>> SearchAsync(SearchRequest request)
        {
            return await _context.Games
                .Include(g => g.Category)
                .Where(game => !request.CategoryId.HasValue || game.CategoryId == request.CategoryId.Value)
                .Where(game => string.IsNullOrEmpty(request.Term) || game.Title.ToLower().Contains(request.Term.ToLower()))
                .Select(game => new GameResponse
                {
                    Id = game.Id,
                    Title = game.Title,
                    Description = game.Description,
                    ImageUrl = game.ImageUrl,
                    CategoryId = game.CategoryId ?? 0,
                    CategoryName = game.Category != null ? game.Category.CategoryName : "No Category"
                })
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
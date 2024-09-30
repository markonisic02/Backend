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

        public async Task<List<Game>> GetAllAsync()

        {
            return await _context.Games.ToListAsync();
        }
    }
}
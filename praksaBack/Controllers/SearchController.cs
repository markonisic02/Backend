using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using praksaBack.Data;
using praksaBack.Models;

namespace praksaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public SearchController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] SearchRequest request)
        {
            var query = _context.Games.Include(g => g.Category).AsQueryable();
            if (request.CategoryId.HasValue)
            {
                query = query.Where(game => game.CategoryId == request.CategoryId.Value);
            }
            if (!string.IsNullOrEmpty(request.Term))
            {
                query = query.Where(game => game.Title.ToLower().Contains(request.Term.ToLower()));
            }
            var result = query.Select(game => new GameResponse
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                CategoryId = game.CategoryId.HasValue ? game.CategoryId.Value : 0,
                CategoryName = game.Category != null ? game.Category.CategoryName : "No Category"
            }).ToList();
            return Ok(result);
        }
    }
}
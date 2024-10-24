using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using praksaBack.Data;
using praksaBack.Dtos.Category;
using praksaBack.Dtos.Game;
using praksaBack.Interfaces;
using praksaBack.Mappers;
using praksaBack.Models;

namespace praksaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IGamesRepository _gameRepo;
        private readonly ICategoryRepository _categoryRepo;

        public GamesController(ApplicationDBContext context, IGamesRepository gameRepo, ICategoryRepository categoryRepo)
        {
            _context = context;
            _gameRepo = gameRepo;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameRepo.GetAllAsync();
            var gameDto = games.Select(s => s.ToGameDto());
            return Ok(gameDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _gameRepo.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game.ToGameDto());
        }

        [HttpPost("{categoryId:int}")]
        public async Task<IActionResult> Create([FromRoute] int categoryId, CreateGameDto gameDto)
        {
            if (!await _categoryRepo.CategoryExists(categoryId))
            {
                return BadRequest("Category does not exist");
            }
            var gameModel = gameDto.ToGameFromCreate(categoryId);
            await _gameRepo.CreateAsync(gameModel);
            return CreatedAtAction(nameof(GetById), new { id = gameModel.Id }, gameModel.ToGameDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGameRequestDto updateDto)
        {
            var game = await _gameRepo.UpdateAsync(id, updateDto.ToGameFromUpdate());
            if (game == null)
            {
                return NotFound("Game not found");
            }
            return Ok(game.ToGameDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var gameModel = await _gameRepo.DeleteAsync(id);
            if (gameModel == null)
            {
                return NotFound("Game does not exist");
            }
            return Ok(gameModel);
        }

        [HttpPost("search")]
        public IActionResult Search([FromBody] SearchRequest request)
        {
            // Pretpostavljamo da koristimo DbContext _context za pristup bazi podataka
            var query = _context.Games.Include(g => g.Category).AsQueryable();  // Uključujemo Category u upit

            // Filtriranje po CategoryId ako je poslat
            if (request.CategoryId.HasValue)
            {
                query = query.Where(game => game.CategoryId == request.CategoryId.Value);
            }

            // Filtriranje po Term ako je poslat
            if (!string.IsNullOrEmpty(request.Term))
            {
                query = query.Where(game => game.Title.ToLower().Contains(request.Term.ToLower()));
            }

            // Preuzimamo rezultate i projektujemo u odgovarajući format
            var result = query.Select(game => new GameResponse
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                CategoryId = game.CategoryId.HasValue ? game.CategoryId.Value : 0,  // Ako je CategoryId null, postavi 0
                CategoryName = game.Category != null ? game.Category.CategoryName : "No Category"  // Ako nema kategorije, "No Category"
            }).ToList();

            return Ok(result);
        }
    }
}
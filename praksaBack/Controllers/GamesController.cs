using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using praksaBack.Data;
using praksaBack.Interfaces;
using praksaBack.Mappers;

namespace praksaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IGamesRepository _gameRepo;

        public GamesController(ApplicationDBContext context, IGamesRepository gameRepo)
        {
            _context = context;
            _gameRepo = gameRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameRepo.GetAllAsync();
            var gameDto = games.Select(s => s.ToGameDto());
            return Ok(gameDto);
        }
    }
}
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
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gamesService.GetAllAsync();

            return Ok(games);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _gamesService.GetByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost("{categoryId:int}")]
        public async Task<IActionResult> Create(CreateGameDto gameDto)
        {
            var createdGame = await _gamesService.CreateAsync(gameDto);
            return CreatedAtAction(nameof(GetById), new { id = createdGame.Id }, createdGame);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGameRequestDto updateDto)
        {
            var updatedGame = await _gamesService.UpdateAsync(id, updateDto);
            return updatedGame == null ? NotFound() : Ok(updatedGame);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deleted = await _gamesService.DeleteAsync(id);
            return Ok(deleted);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] SearchRequest request)
        {
            var results = await _gamesService.SearchAsync(request);
            return Ok(results);
        }
    }
}
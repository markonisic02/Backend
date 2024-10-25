using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using praksaBack.Data;
using praksaBack.Dtos.Category;
using praksaBack.Interfaces;
using praksaBack.Mappers;

namespace praksaBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICategoryRepository _categoryRepo;

        public CategoriesController(ApplicationDBContext context, ICategoryRepository categoryRepo)
        {
            _context = context;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepo.GetAllAsync();
            var categoryDto = categories.Select(s => s.ToCategoryDto());
            return Ok(categoryDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromCreateDto();
            await _categoryRepo.CreateAsync(categoryModel);
            return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());  // AKO PUKNE VJEROVATNO OVDJE TREBA GetById napravit
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            var gamesExist = _context.Games.Any(g => g.CategoryId == id);
            if (gamesExist)
            {
                return StatusCode(606, "Postoje igrice u ovoj kategoriji");
            }

            var categoryModel = await _categoryRepo.DeleteAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CategoryDto categoryDto)
        {
            var category = await _categoryRepo.UpdateAsync(id, categoryDto.ToCategoryFromUpdate());
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category.ToCategoryDto());
        }
    }
}
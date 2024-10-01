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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequestDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromCreateDto();
            await _categoryRepo.CreateAsync(categoryModel);
            return CreatedAtAction(nameof(GetAll), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());  // AKO PUKNE VJEROVATNO OVDJE TREBA GetById napravit
        }
    }
}
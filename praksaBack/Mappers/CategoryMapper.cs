using praksaBack.Dtos.Category;
using praksaBack.Models;

namespace praksaBack.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryDto ToCategoryDto(this Category categoryModel)
        {
            return new CategoryDto
            {
                Id = categoryModel.Id,
                CategoryName = categoryModel.CategoryName,
                Games = categoryModel.Games.Select(c => c.ToGameDto()).ToList()
            };
        }

        public static Category ToCategoryFromCreateDto(this CreateCategoryRequestDto categoryDto)
        {
            return new Category
            {
                CategoryName = categoryDto.CategoryName
            };
        }
    }
}
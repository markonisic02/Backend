using System.ComponentModel.DataAnnotations;

namespace praksaBack.Dtos.Category
{
    public class CreateCategoryRequestDto
    {
        [Required]
        [MaxLength(20, ErrorMessage = "Category name cannot be over 20 characters")]
        public string CategoryName { get; set; } = string.Empty;
    }
}
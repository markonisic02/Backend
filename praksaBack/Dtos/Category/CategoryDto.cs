using praksaBack.Dtos.Game;

namespace praksaBack.Dtos.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public List<GameDto> Games { get; set; }
    }
}
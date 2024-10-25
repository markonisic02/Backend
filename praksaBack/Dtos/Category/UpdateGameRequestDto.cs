namespace praksaBack.Dtos.Category
{
    public class UpdateGameRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId{ get; set; }
    }
}
namespace praksaBack.Models
{
    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
namespace praksaBack.Dtos.Game
{
    public class CreateGameDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}
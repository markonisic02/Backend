namespace praksaBack.Models
{
    public class SearchRequest
    {
        public string Term { get; set; } = string.Empty;
        public int? CategoryId { get; set; } = null;
    }
}
using praksaBack.Dtos.Comment;

namespace praksaBack.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;

        public double Purchase { get; set; }

        public double LastDiv { get; set; }

        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto> Comments { get; set; }
        //Comments
    }
}
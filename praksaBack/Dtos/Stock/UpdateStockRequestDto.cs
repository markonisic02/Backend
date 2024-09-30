using System.ComponentModel.DataAnnotations;

namespace praksaBack.Dtos.Stock
{
    public class UpdateStockRequestDto
    {
        [Required]
        [MaxLength(10, ErrorMessage = "Symbol cannot be over 10 characters")]
        public string Symbol { get; set; } = string.Empty;

        [Required]
        [MaxLength(10, ErrorMessage = "Company name cannot be over 10 characters")]
        public string CompanyName { get; set; } = string.Empty;

        [Required]
        [Range(1, 1000000000)]
        public double Purchase { get; set; }

        public double LastDiv { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "Industry cannot be over 10 characters")]
        public string Industry { get; set; } = string.Empty;

        [Required]
        [Range(1, 90000000)]
        public long MarketCap { get; set; }
    }
}
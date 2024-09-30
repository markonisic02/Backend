using praksaBack.Dtos.Stock;
using praksaBack.Models;
using System.Runtime.CompilerServices;

namespace praksaBack.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
                Comments = stockModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockdto)
        {
            return new Stock
            {
                Symbol = stockdto.Symbol,
                CompanyName = stockdto.CompanyName,
                Purchase = stockdto.Purchase,
                LastDiv = stockdto.LastDiv,
                Industry = stockdto.Industry,
                MarketCap = stockdto.MarketCap
            };
        }
    }
}
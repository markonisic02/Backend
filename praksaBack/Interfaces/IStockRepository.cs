using praksaBack.Dtos.Stock;
using praksaBack.Helpers;
using praksaBack.Models;

namespace praksaBack.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);

        Task<Stock?> GetByIdAsync(int id); //FirstOrDefault

        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);

        Task<Stock?> DeleteAsync(int id);

        Task<bool> StockExists(int id);
    }
}
using practice_web_apis.Models;

namespace practice_web_apis.Repository.StockRepo
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllAsync();
        public Task<Stock?> GetByIdAsync(int id);
        public Task<bool> CheckExist(int id);
    }
}

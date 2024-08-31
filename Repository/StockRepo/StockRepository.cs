using Microsoft.EntityFrameworkCore;
using practice_web_apis.Data;
using practice_web_apis.Models;

namespace practice_web_apis.Repository.StockRepo
{
    public class StockRepository : IStockRepository
    {
        private readonly AppDbContext _db;
        public StockRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckExist(int id)
        {
            return await _db.Stocks.AnyAsync(s => s.Id == id);
        }

        public async Task<List<Stock>> GetAllAsync()
        {
           return await _db.Stocks.Include(s => s.Comments).ToListAsync();
        }
        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _db.Stocks.Include(s => s.Comments).FirstOrDefaultAsync(s => s.Id == id);
        }

    }
}

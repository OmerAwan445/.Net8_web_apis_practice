

using practice_web_apis.Models;

namespace practice_web_apis.Repository.StockRepo
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
    }
}
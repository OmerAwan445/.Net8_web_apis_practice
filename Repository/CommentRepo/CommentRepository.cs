using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using practice_web_apis.Data;
using practice_web_apis.Models;
using practice_web_apis.Repository.StockRepo;

namespace practice_web_apis.Repository.CommentRepo
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext db;
        public CommentRepository(AppDbContext _db)
        {
            db = _db;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
           return await db.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await db.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

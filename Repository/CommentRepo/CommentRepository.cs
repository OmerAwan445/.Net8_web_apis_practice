using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using practice_web_apis.Data;
using practice_web_apis.Models;
using practice_web_apis.Repository.StockRepo;

namespace practice_web_apis.Repository.CommentRepo
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _db;
        public CommentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckExist(int CommentId)
        {
            return await _db.Comments.AnyAsync(comm => comm.Id == CommentId);
        }

        public async Task<Comment> CreateAsync(Comment CommentModel)
        {
           var comment = await _db.Comments.AddAsync(CommentModel);
            await _db.SaveChangesAsync();
            return comment.Entity;
        }

        public async Task DeleteCommentAsync(Comment existingComment)
        {
            _db.Comments.Remove(existingComment);
            await _db.SaveChangesAsync();
        }

        public async Task<Comment?> FindCommentAsync(int CommentId)
        {
            return await _db.Comments.FindAsync(CommentId);
        }

        public async Task<List<Comment>> GetAllAsync()
        {
           return await _db.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _db.Comments.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task SaveDbChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}



using Microsoft.AspNetCore.Mvc;
using practice_web_apis.Models;

namespace practice_web_apis.Repository.StockRepo
{
    public interface ICommentRepo
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment> GetByIdAsync(int id);
        Task<Comment> CreateAsync(Comment comment);
        Task<bool> CheckExist(int CommentId);
        Task<Comment?> FindCommentAsync(int CommentId);
        Task DeleteCommentAsync(Comment existingComment);
        Task SaveDbChangesAsync();
    }
}
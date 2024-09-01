
namespace practice_web_apis.Dtos
{
    public record CommentDto(int Id, string Title, string Content, DateTime CreatedOn = default, int? StockId = null);
    public record CreateCommentDto(string Title, string Content);
}
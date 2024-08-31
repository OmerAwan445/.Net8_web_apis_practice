
using System.Runtime.CompilerServices;
using practice_web_apis.Dtos;
using practice_web_apis.Models;

namespace practice_web_apis.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId 
            };
        }

        public static Comment FromCreateCommentDtoToComment (this CreateCommentDto _CommentDto, int StockId)
        {
            return new Comment
            {
                Title = _CommentDto.Title,
                Content = _CommentDto.Content,
                StockId = StockId
            };
        }

    }
}
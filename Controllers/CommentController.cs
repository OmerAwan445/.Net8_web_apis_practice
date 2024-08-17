using Microsoft.AspNetCore.Mvc;
using practice_web_apis.Dtos;
using practice_web_apis.Mappers;
using practice_web_apis.Models;
using practice_web_apis.Repository.StockRepo;

namespace practice_web_apis.Controllers
{
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;
        public CommentController(ICommentRepository commentRepo)
        {
            commentRepository = commentRepo;
        }

        [HttpGet(Name = "Get All comments")]
        [ProducesResponseType(typeof(List<CommentDto>), 200)]
        public async Task<IActionResult> GetAllComments()
        {
            var data = await commentRepository.GetAllAsync();
            if(data is null ) return NotFound("No comments found");
            var commentsDtos = data.Select(c => CommentMapper.ToCommentDto(c));
            
            return Ok(commentsDtos);
        }
        
        [HttpGet("{Id}", Name = "Get comment by ID")]
        [ProducesResponseType(typeof(Comment), 200)]
        public async Task<IActionResult> GetCommentById([FromRoute] int Id) {
            var data = await commentRepository.GetByIdAsync(Id);
            if (data is null) return NotFound($"No Comment with id: {Id}"); 
            return Ok(CommentMapper.ToCommentDto(data));
        }
    }
}

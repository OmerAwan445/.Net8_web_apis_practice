using Microsoft.AspNetCore.Mvc;
using practice_web_apis.Dtos;
using practice_web_apis.Mappers;
using practice_web_apis.Models;
using practice_web_apis.Repository.StockRepo;

namespace practice_web_apis.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            commentRepository = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet(Name = "Get All comments")]
        [ProducesResponseType(typeof(List<CommentDto>), 200)]
        public async Task<IActionResult> GetAllComments()
        {
            var data = await commentRepository.GetAllAsync();
            if (data is null) return NotFound("No comments found");
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

        [ProducesResponseType(typeof(Comment), 201)]
        [HttpPost]
        [Route("{StockId}")]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDto commentDto, [FromRoute] int StockId)
        {
            bool IsExist = await _stockRepo.CheckExist(StockId);
            if(!IsExist) return NotFound($"No Stock with id: {StockId}");

            Comment NewComment = CommentMapper.FromCreateCommentDtoToComment(commentDto, StockId);
            var createdComment = await commentRepository.CreateAsync(NewComment);

            return Ok(createdComment);
        }
        
        [ProducesResponseType(typeof(Comment), 203)]
        [HttpPut]
        [Route("{CommentId}")]
        public async Task<IActionResult> UpdateComment([FromBody] CreateCommentDto commentDto, [FromRoute] int CommentId)
        {
            var existingComment = await commentRepository.FindCommentAsync(CommentId);
            if(existingComment is null) return NotFound($"No Comment with id: {CommentId}");

            existingComment.Content = commentDto.Content;
            existingComment.Title = commentDto.Title;

            await commentRepository.SaveDbChangesAsync();
            return Ok(CommentMapper.ToCommentDto(existingComment));
        }
        
        

        [HttpDelete]
        [Route("{CommentId}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int CommentId)
        {
            var existingComment = await commentRepository.FindCommentAsync(CommentId);
            if(existingComment is null) return NotFound($"No Comment with id: {CommentId}");
            await commentRepository.DeleteCommentAsync(existingComment);

            return Ok(CommentMapper.ToCommentDto(existingComment));
        }


    }
}

using Microsoft.AspNetCore.Mvc;
using practice_web_apis.Data;
using practice_web_apis.Dtos;
using practice_web_apis.Models;
using practice_web_apis.Mappers;
using Microsoft.EntityFrameworkCore;
using practice_web_apis.Repository.StockRepo;

namespace practice_web_apis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IStockRepo stockRepo;

        public StockController(AppDbContext db, IStockRepo _stockRepo)
        {
            _db = db;
            stockRepo = _stockRepo;
        }

        [HttpGet(Name = "Get all Stocks")]
        [ProducesResponseType(typeof(List<StockResponseDto>), 200)]
        public async Task <IActionResult> GetStocks()
        {
                var data = await stockRepo.GetAllAsync();
                var stockDataDto = data.Select(data => StockMapper.toStockResDto(data));
                return Ok(stockDataDto);
         }


        [HttpGet("{Id}", Name ="Get Stock By Id")]
        public async Task<IActionResult> GetStockById([FromRoute] int Id)
        {
            try
            {
                var data = await stockRepo.GetByIdAsync(Id);
                if(data is null ) return NotFound($"Stock with id:{Id} not Found");
                return Ok(StockMapper.toStockResDto(data));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost(Name = "Create Stocks")]
        [ProducesResponseType(typeof(StockResponseDto), 201)]
        public async Task<IActionResult> CreateStock([FromBody] StockRequestDto stockDto)
        {
            var stockModel = StockMapper.toStockFromRequetDto(stockDto);
            await _db.Stocks.AddAsync(stockModel);
            await _db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetStockById), new { id = stockModel.Id }, StockMapper.toStockResDto(stockModel));
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(typeof(StockResponseDto), 200)]
        public async Task<ActionResult<StockResponseDto>> UpdateStock([FromRoute] int Id, [FromBody] StockRequestDto stockUpdatedData)
        {
            var existingStock = await _db.Stocks.FindAsync(Id);
            if(existingStock is null ) return NotFound($"Stock with id:{Id} not Found");
            existingStock.Symbol = stockUpdatedData.Symbol;
            existingStock.CompanyName = stockUpdatedData.CompanyName;
            existingStock.Purchase = stockUpdatedData.Purchase;
            existingStock.LastDiv = stockUpdatedData.LastDiv;
            existingStock.Industry = stockUpdatedData.Industry;
            existingStock.MarketCap = stockUpdatedData.MarketCap;
            await _db.SaveChangesAsync();
            return Ok(StockMapper.toStockResDto(existingStock));
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<ActionResult> DeleteStock([FromRoute] int Id)
        {
            var existingStock = await _db.Stocks.FindAsync(Id);
            if (existingStock is null) return NotFound($"Stock with id:{Id} not Found");
            _db.Stocks.Remove(existingStock);
            await _db.SaveChangesAsync();
            return NoContent();
        }

    }
}

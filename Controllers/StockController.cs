using Microsoft.AspNetCore.Mvc;
using practice_web_apis.Data;
using practice_web_apis.Models;

namespace practice_web_apis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private AppDbContext _db;
        public StockController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult CreateStocks(Stock stockData)
        {
            try
            {

                _db.Stocks.Add(stockData);
                _db.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

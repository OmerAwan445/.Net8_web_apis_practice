using practice_web_apis.Dtos;
using practice_web_apis.Models;

namespace practice_web_apis.Mappers
{
    public static class StockMapper
    {
        public static StockResponseDto toStockResDto(Stock dataModel)
        {
            return new StockResponseDto{ 
                Id = dataModel.Id,
                Symbol = dataModel.Symbol,
                CompanyName = dataModel.CompanyName,
                LastDiv = dataModel.LastDiv,
                Industry = dataModel.Industry,
                MarketCap = dataModel.MarketCap,
                Comments = dataModel.Comments.Select(c => CommentMapper.ToCommentDto(c)).ToList()
                
            };
        }

        public static Stock toStockFromRequetDto(StockRequestDto reqStockData)
        {
            return new Stock {
            Symbol = reqStockData.Symbol,
            CompanyName = reqStockData.CompanyName,
            Purchase = reqStockData.Purchase,
            LastDiv = reqStockData.LastDiv,
            Industry = reqStockData.Industry,
            MarketCap = reqStockData.MarketCap
            };
        }
    }
}

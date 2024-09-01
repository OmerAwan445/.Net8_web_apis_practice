using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using practice_web_apis.Models;

namespace practice_web_apis.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().HasData(
               new Stock
               {
                   Id = 1,
                   Symbol = "AAPL",
                   CompanyName = "Apple Inc.",
                   Purchase = 150.75m,
                   LastDiv = 0.82m,
                   Industry = "Technology",
                   MarketCap = 2700000000000 // 2.7 trillion
               },
    new Stock
    {
        Id = 2,
        Symbol = "MSFT",
        CompanyName = "Microsoft Corporation",
        Purchase = 310.10m,
        LastDiv = 1.56m,
        Industry = "Technology",
        MarketCap = 2500000000000 // 2.5 trillion
    },
    new Stock
    {
        Id = 3,
        Symbol = "TSLA",
        CompanyName = "Tesla, Inc.",
        Purchase = 650.25m,
        LastDiv = 0.00m, // Tesla doesn't pay dividends
        Industry = "Automotive",
        MarketCap = 800000000000 // 800 billion
    },
    new Stock
    {
        Id = 4,
        Symbol = "AMZN",
        CompanyName = "Amazon.com, Inc.",
        Purchase = 3300.50m,
        LastDiv = 0.00m, // Amazon doesn't pay dividends
        Industry = "E-commerce",
        MarketCap = 1600000000000 // 1.6 trillion
    },
    new Stock
    {
        Id = 5,
        Symbol = "GOOGL",
        CompanyName = "Alphabet Inc.",
        Purchase = 2800.75m,
        LastDiv = 0.00m, // Alphabet doesn't pay dividends
        Industry = "Technology",
        MarketCap = 1800000000000 // 1.8 trillion
    },
    new Stock
    {
        Id = 6,
        Symbol = "NFLX",
        CompanyName = "Netflix, Inc.",
        Purchase = 550.00m,
        LastDiv = 0.00m, // Netflix doesn't pay dividends
        Industry = "Entertainment",
        MarketCap = 250000000000 // 250 billion
    }
               );
        }*/
    }
}

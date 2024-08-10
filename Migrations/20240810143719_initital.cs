using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace practice_web_apis.Migrations
{
    /// <inheritdoc />
    public partial class initital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LastDiv = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Industry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MarketCap = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "CompanyName", "Industry", "LastDiv", "MarketCap", "Purchase", "Symbol" },
                values: new object[,]
                {
                    { 1, "Apple Inc.", "Technology", 0.82m, 2700000000000L, 150.75m, "AAPL" },
                    { 2, "Microsoft Corporation", "Technology", 1.56m, 2500000000000L, 310.10m, "MSFT" },
                    { 3, "Tesla, Inc.", "Automotive", 0.00m, 800000000000L, 650.25m, "TSLA" },
                    { 4, "Amazon.com, Inc.", "E-commerce", 0.00m, 1600000000000L, 3300.50m, "AMZN" },
                    { 5, "Alphabet Inc.", "Technology", 0.00m, 1800000000000L, 2800.75m, "GOOGL" },
                    { 6, "Netflix, Inc.", "Entertainment", 0.00m, 250000000000L, 550.00m, "NFLX" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Auction.Repository.Migrations
{
    public partial class addAuctionDetailsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionWinnerDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinnerName = table.Column<string>(nullable: true),
                    ItemName = table.Column<string>(nullable: true),
                    StartingPrice = table.Column<double>(nullable: false),
                    PricePaid = table.Column<double>(nullable: false),
                    Profit = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionWinnerDetails", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionWinnerDetails");
        }
    }
}

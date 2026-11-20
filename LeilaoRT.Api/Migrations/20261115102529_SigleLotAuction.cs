using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeilaoRT.Api.Migrations
{
    /// <inheritdoc />
    public partial class SigleLotAuction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Item_AuctionId",
                table: "Item");

            migrationBuilder.CreateIndex(
                name: "IX_Item_AuctionId_LotNumber",
                table: "Item",
                columns: new[] { "AuctionId", "LotNumber" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Item_AuctionId_LotNumber",
                table: "Item");

            migrationBuilder.CreateIndex(
                name: "IX_Item_AuctionId",
                table: "Item",
                column: "AuctionId");
        }
    }
}

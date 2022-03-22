using Microsoft.EntityFrameworkCore.Migrations;

namespace Schemasforfarmer.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FarmerDetailsModels",
                table: "FarmerDetailsModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BidderDetailsModels",
                table: "BidderDetailsModels");

            migrationBuilder.RenameTable(
                name: "FarmerDetailsModels",
                newName: "tbl_FarmerDetails");

            migrationBuilder.RenameTable(
                name: "BidderDetailsModels",
                newName: "tbl_BidderDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_FarmerDetails",
                table: "tbl_FarmerDetails",
                column: "FarmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_BidderDetails",
                table: "tbl_BidderDetails",
                column: "BidderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_FarmerDetails",
                table: "tbl_FarmerDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_BidderDetails",
                table: "tbl_BidderDetails");

            migrationBuilder.RenameTable(
                name: "tbl_FarmerDetails",
                newName: "FarmerDetailsModels");

            migrationBuilder.RenameTable(
                name: "tbl_BidderDetails",
                newName: "BidderDetailsModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FarmerDetailsModels",
                table: "FarmerDetailsModels",
                column: "FarmerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BidderDetailsModels",
                table: "BidderDetailsModels",
                column: "BidderId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Schemasforfarmer.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BidderDetailsModels",
                columns: table => new
                {
                    BidderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidderFullName = table.Column<string>(nullable: true),
                    BidderContact = table.Column<string>(nullable: true),
                    BidderEmail = table.Column<string>(nullable: true),
                    BidderAddress = table.Column<string>(nullable: true),
                    BidderCity = table.Column<string>(nullable: true),
                    BidderState = table.Column<string>(nullable: true),
                    BidderPincode = table.Column<int>(nullable: true),
                    BidderAccountNumber = table.Column<int>(nullable: true),
                    BidderIfscCode = table.Column<string>(nullable: true),
                    BidderAdharCard = table.Column<int>(nullable: true),
                    BidderPan = table.Column<string>(nullable: true),
                    BidderTraderLicense = table.Column<string>(nullable: true),
                    BidderPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidderDetailsModels", x => x.BidderId);
                });

            migrationBuilder.CreateTable(
                name: "FarmerDetailsModels",
                columns: table => new
                {
                    FarmerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FarmerFullName = table.Column<string>(nullable: true),
                    FarmerContact = table.Column<string>(nullable: true),
                    FarmerEmail = table.Column<string>(nullable: true),
                    FarmerAddress = table.Column<string>(nullable: true),
                    FarmerCity = table.Column<string>(nullable: true),
                    FarmerState = table.Column<string>(nullable: true),
                    FarmerPincode = table.Column<int>(nullable: true),
                    FarmerAccountNumber = table.Column<int>(nullable: false),
                    FarmerIfscCode = table.Column<string>(nullable: true),
                    FarmerAdharCard = table.Column<int>(nullable: true),
                    FarmerPan = table.Column<string>(nullable: true),
                    FarmerTraderLicense = table.Column<string>(nullable: true),
                    FarmerPassword = table.Column<string>(nullable: true),
                    FarmerLandArea = table.Column<string>(nullable: true),
                    FarmerLandAddress = table.Column<string>(nullable: true),
                    FarmerLandPincode = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FarmerDetailsModels", x => x.FarmerId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_CropType",
                columns: table => new
                {
                    CropTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_CropType", x => x.CropTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Insurance",
                columns: table => new
                {
                    InsuranceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticularsOfInsuree = table.Column<string>(nullable: true),
                    PolicyNo = table.Column<int>(nullable: true),
                    InsuranceCompany = table.Column<string>(nullable: true),
                    NameOfInsuree = table.Column<string>(nullable: true),
                    SumInsured = table.Column<decimal>(nullable: true),
                    CauseOfLoss = table.Column<string>(nullable: true),
                    DateOfLoss = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Insurance", x => x.InsuranceId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserDetails",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserDetails", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Policy",
                columns: table => new
                {
                    PolicyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Season = table.Column<string>(nullable: true),
                    Year = table.Column<DateTime>(nullable: true),
                    CropName = table.Column<string>(nullable: true),
                    SumInsured = table.Column<decimal>(nullable: true),
                    Area = table.Column<decimal>(nullable: true),
                    InsuranceCompany = table.Column<string>(nullable: true),
                    SumInsuredperhect = table.Column<decimal>(nullable: true),
                    SharePremium = table.Column<decimal>(nullable: true),
                    PremiumAmount = table.Column<decimal>(nullable: true),
                    PolicyNo = table.Column<int>(nullable: true),
                    PolicyNoNavigationInsuranceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Policy", x => x.PolicyId);
                    table.ForeignKey(
                        name: "FK_tbl_Policy_tbl_Insurance_PolicyNoNavigationInsuranceId",
                        column: x => x.PolicyNoNavigationInsuranceId,
                        principalTable: "tbl_Insurance",
                        principalColumn: "InsuranceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_UserInfo",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    ContactNo = table.Column<int>(nullable: false),
                    EmailId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Pincode = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    PermittedtoSale = table.Column<string>(nullable: true),
                    UserTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_UserInfo", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_tbl_UserInfo_tbl_UserDetails_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "tbl_UserDetails",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_BankData",
                columns: table => new
                {
                    BankId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNo = table.Column<int>(nullable: true),
                    Ifsccode = table.Column<string>(nullable: true),
                    Adhar = table.Column<int>(nullable: true),
                    Pan = table.Column<string>(nullable: true),
                    TraderLicense = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_BankData", x => x.BankId);
                    table.ForeignKey(
                        name: "FK_tbl_BankData_tbl_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_LoginInfo",
                columns: table => new
                {
                    LoginId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    UserTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_LoginInfo", x => x.LoginId);
                    table.ForeignKey(
                        name: "FK_tbl_LoginInfo_tbl_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_LoginInfo_tbl_UserDetails_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "tbl_UserDetails",
                        principalColumn: "UserTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_PlaceSellRequest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropType = table.Column<string>(nullable: true),
                    CropName = table.Column<string>(nullable: true),
                    FertilizerType = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    SoilPhCertificate = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_PlaceSellRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_PlaceSellRequest_tbl_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Sell",
                columns: table => new
                {
                    SellId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropName = table.Column<string>(nullable: true),
                    FertilizerType = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    BasePrice = table.Column<decimal>(nullable: true),
                    CropTypeId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Sell", x => x.SellId);
                    table.ForeignKey(
                        name: "FK_tbl_Sell_tbl_CropType_CropTypeId",
                        column: x => x.CropTypeId,
                        principalTable: "tbl_CropType",
                        principalColumn: "CropTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Sell_tbl_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ViewMarketPlace",
                columns: table => new
                {
                    MarketPlaceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropType = table.Column<string>(nullable: true),
                    CropName = table.Column<string>(nullable: true),
                    BasePrice = table.Column<decimal>(nullable: true),
                    CurrentBid = table.Column<decimal>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ViewMarketPlace", x => x.MarketPlaceId);
                    table.ForeignKey(
                        name: "FK_tbl_ViewMarketPlace_tbl_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_ViewSoldCropHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: true),
                    CropName = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(nullable: true),
                    Msp = table.Column<decimal>(nullable: true),
                    SolidPrice = table.Column<decimal>(nullable: true),
                    TotalPrice = table.Column<decimal>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ViewSoldCropHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_ViewSoldCropHistory_tbl_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Welcome",
                columns: table => new
                {
                    WelcomeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CropName = table.Column<string>(nullable: true),
                    CropType = table.Column<string>(nullable: true),
                    BasePrice = table.Column<decimal>(nullable: true),
                    CurrentBid = table.Column<decimal>(nullable: true),
                    Bidammount = table.Column<decimal>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Welcome", x => x.WelcomeId);
                    table.ForeignKey(
                        name: "FK_tbl_Welcome_tbl_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Bidding",
                columns: table => new
                {
                    BiddingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BidAmt = table.Column<decimal>(nullable: true),
                    BidDate = table.Column<DateTime>(nullable: true),
                    IsBitStatus = table.Column<bool>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    SellId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Bidding", x => x.BiddingId);
                    table.ForeignKey(
                        name: "FK_tbl_Bidding_tbl_Sell_SellId",
                        column: x => x.SellId,
                        principalTable: "tbl_Sell",
                        principalColumn: "SellId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_Bidding_tbl_UserInfo_UserId",
                        column: x => x.UserId,
                        principalTable: "tbl_UserInfo",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_BankData_UserId",
                table: "tbl_BankData",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Bidding_SellId",
                table: "tbl_Bidding",
                column: "SellId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Bidding_UserId",
                table: "tbl_Bidding",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LoginInfo_UserId",
                table: "tbl_LoginInfo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_LoginInfo_UserTypeId",
                table: "tbl_LoginInfo",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_PlaceSellRequest_UserId",
                table: "tbl_PlaceSellRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Policy_PolicyNoNavigationInsuranceId",
                table: "tbl_Policy",
                column: "PolicyNoNavigationInsuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Sell_CropTypeId",
                table: "tbl_Sell",
                column: "CropTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Sell_UserId",
                table: "tbl_Sell",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_UserInfo_UserTypeId",
                table: "tbl_UserInfo",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ViewMarketPlace_UserId",
                table: "tbl_ViewMarketPlace",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ViewSoldCropHistory_UserId",
                table: "tbl_ViewSoldCropHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Welcome_UserId",
                table: "tbl_Welcome",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidderDetailsModels");

            migrationBuilder.DropTable(
                name: "FarmerDetailsModels");

            migrationBuilder.DropTable(
                name: "tbl_BankData");

            migrationBuilder.DropTable(
                name: "tbl_Bidding");

            migrationBuilder.DropTable(
                name: "tbl_LoginInfo");

            migrationBuilder.DropTable(
                name: "tbl_PlaceSellRequest");

            migrationBuilder.DropTable(
                name: "tbl_Policy");

            migrationBuilder.DropTable(
                name: "tbl_ViewMarketPlace");

            migrationBuilder.DropTable(
                name: "tbl_ViewSoldCropHistory");

            migrationBuilder.DropTable(
                name: "tbl_Welcome");

            migrationBuilder.DropTable(
                name: "tbl_Sell");

            migrationBuilder.DropTable(
                name: "tbl_Insurance");

            migrationBuilder.DropTable(
                name: "tbl_CropType");

            migrationBuilder.DropTable(
                name: "tbl_UserInfo");

            migrationBuilder.DropTable(
                name: "tbl_UserDetails");
        }
    }
}

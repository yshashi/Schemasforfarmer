using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Schemasforfarmer.BusinessAccessLayer.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schemasforfarmer.Models
{
    public partial class AgricultureContext : DbContext
    {
        public AgricultureContext()
        {
        }

        public AgricultureContext(DbContextOptions<AgricultureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplyForPolicy> ApplyForPolicy { get; set; }
        public virtual DbSet<BidderDetailsModel> BidderDetailsModels { get; set; }
        public virtual DbSet<FarmerDetailsModel> FarmerDetailsModels { get; set; }
        public virtual DbSet<BankDetails> BankDetails { get; set; }
        public virtual DbSet<BidderWelcomePage> BidderWelcomePage { get; set; }
        public virtual DbSet<Bidding> Bidding { get; set; }
        public virtual DbSet<ClaimInsurance> ClaimInsurance { get; set; }
        public virtual DbSet<CropType> CropType { get; set; }
        public virtual DbSet<LoginInfo> LoginInfo { get; set; }
        public virtual DbSet<PlaceSellRequest> PlaceSellRequest { get; set; }
        public virtual DbSet<Sell> Sell { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<ViewMarketPlace> ViewMarketPlace { get; set; }
        public virtual DbSet<ViewSoldCropHistory> ViewSoldCropHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplyForPolicy>().ToTable("tbl_Policy");

            modelBuilder.Entity<BankDetails>().ToTable("tbl_BankData");
            modelBuilder.Entity<BidderDetailsModel>().ToTable("tbl_BidderDetails");

            modelBuilder.Entity<FarmerDetailsModel>().ToTable("tbl_FarmerDetails");

            modelBuilder.Entity<BidderWelcomePage>().ToTable("tbl_Welcome");

            modelBuilder.Entity<Bidding>().ToTable("tbl_Bidding");

            modelBuilder.Entity<ClaimInsurance>().ToTable("tbl_Insurance");

            modelBuilder.Entity<CropType>().ToTable("tbl_CropType");

            modelBuilder.Entity<LoginInfo>().ToTable("tbl_LoginInfo");

            modelBuilder.Entity<PlaceSellRequest>().ToTable("tbl_PlaceSellRequest");

            modelBuilder.Entity<Sell>().ToTable("tbl_Sell");

            modelBuilder.Entity<UserDetails>().ToTable("tbl_UserDetails");

            modelBuilder.Entity<UserInfo>().ToTable("tbl_UserInfo");

            modelBuilder.Entity<ViewMarketPlace>().ToTable("tbl_ViewMarketPlace");

            modelBuilder.Entity<ViewSoldCropHistory>().ToTable("tbl_ViewSoldCropHistory");
        }


    }
}

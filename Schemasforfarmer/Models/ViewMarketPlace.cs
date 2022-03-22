using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schemasforfarmer.Models
{
    public partial class ViewMarketPlace
    {
        [Key]
        public int MarketPlaceId { get; set; }
        public string CropType { get; set; }
        public string CropName { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? CurrentBid { get; set; }
        public int? UserId { get; set; }

        public virtual UserInfo User { get; set; }
    }
}

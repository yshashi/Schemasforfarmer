using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schemasforfarmer.Models
{
    public partial class Bidding
    {
        [Key]
        public int BiddingId { get; set; }
        public decimal? BidAmt { get; set; }
        public DateTime? BidDate { get; set; }
        public bool? IsBitStatus { get; set; }
        public int? UserId { get; set; }
        public int? SellId { get; set; }

        public virtual Sell Sell { get; set; }
        public virtual UserInfo User { get; set; }
    }
}

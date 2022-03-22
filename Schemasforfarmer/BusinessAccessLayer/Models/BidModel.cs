using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class BidModel
    {

        [Key]
        [Column("BiddingId")]
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

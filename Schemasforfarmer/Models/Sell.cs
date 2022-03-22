using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schemasforfarmer.Models
{
    public partial class Sell
    {
        public Sell()
        {
            Bidding = new HashSet<Bidding>();
        }
        [Key]
        public int SellId { get; set; }
        public string CropName { get; set; }
        public string FertilizerType { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? BasePrice { get; set; }
        public int? CropTypeId { get; set; }
        public int? UserId { get; set; }

        public virtual CropType CropType { get; set; }
        public virtual UserInfo User { get; set; }
        public virtual ICollection<Bidding> Bidding { get; set; }
    }
}

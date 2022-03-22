using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schemasforfarmer.Models
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            Bidding = new HashSet<Bidding>();
            PlaceSellRequest = new HashSet<PlaceSellRequest>();
            Sell = new HashSet<Sell>();
            ViewMarketPlace = new HashSet<ViewMarketPlace>();
        }
        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int ContactNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public string Password { get; set; }
        public string PermittedtoSale { get; set; }
        
        public int? UserTypeId { get; set; }

        public virtual UserDetails UserType { get; set; }
        public virtual ICollection<Bidding> Bidding { get; set; }
        public virtual ICollection<PlaceSellRequest> PlaceSellRequest { get; set; }
        public virtual ICollection<Sell> Sell { get; set; }
        public virtual ICollection<ViewMarketPlace> ViewMarketPlace { get; set; }
    }
}

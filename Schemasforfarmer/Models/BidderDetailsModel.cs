using System.ComponentModel.DataAnnotations;

namespace Schemasforfarmer.Models
{
    public class BidderDetailsModel
    {
        [Key]
        public int BidderId { get; set; }
        public string BidderFullName { get; set; }
        public string BidderContact { get; set; }
        public string BidderEmail { get; set; }
        public string BidderAddress { get; set; }
        public string BidderCity { get; set; }
        public string BidderState { get; set; }
        public int BidderPincode { get; set; }
        public int BidderAccountNumber { get; set; }
        public string BidderIfscCode { get; set; }
        public int BidderAdharCard { get; set; }
        public string BidderPan { get; set; }
        public string BidderTraderLicense { get; set; }
        public string BidderPassword { get; set; }
    }
}

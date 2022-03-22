using System.ComponentModel.DataAnnotations;

namespace Schemasforfarmer.Models
{
    public class FarmerDetailsModel
    {
        [Key]
        public int FarmerId { get; set; }
        public string FarmerFullName { get; set; }
        public string FarmerContact { get; set; }
        public string FarmerEmail { get; set; }
        public string FarmerAddress { get; set; }
        public string FarmerCity { get; set; }
        public string FarmerState { get; set; }
        public int FarmerPincode { get; set; }
        public int FarmerAccountNumber { get; set; }
        public string FarmerIfscCode { get; set; }
        public int FarmerAdharCard { get; set; }
        public string FarmerPan { get; set; }
        public string FarmerTraderLicense { get; set; }
        public string FarmerPassword { get; set; }
        public string FarmerLandArea { get; set; }
        public string FarmerLandAddress { get; set; }
        public int FarmerLandPincode { get; set; }
    }
}

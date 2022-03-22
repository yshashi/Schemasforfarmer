using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schemasforfarmer.Models
{
    public partial class ApplyForPolicy
    {
        [Key]
        public int PolicyId { get; set; }
        public string Season { get; set; }
        public DateTime? Year { get; set; }
        public string CropName { get; set; }
        public decimal? SumInsured { get; set; }
        public decimal? Area { get; set; }
        public string InsuranceCompany { get; set; }
        public decimal? SumInsuredperhect { get; set; }
        public decimal? SharePremium { get; set; }
        public decimal? PremiumAmount { get; set; }
        public int? PolicyNo { get; set; }

        public virtual ClaimInsurance PolicyNoNavigation { get; set; }
    }
}

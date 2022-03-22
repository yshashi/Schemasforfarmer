using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class ApplyForPolicyDetail
    {
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
    }
}

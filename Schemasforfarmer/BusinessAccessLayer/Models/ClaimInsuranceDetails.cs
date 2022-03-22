using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class ClaimInsuranceDetails
    {
        [Key]
        [Column("PolicyNo")]
        public string ParticularsOfInsuree { get; set; }
        public int PolicyNo { get; set; }
        public string InsuranceCompany { get; set; }
        public string NameOfInsuree { get; set; }
        public decimal? SumInsured { get; set; }
        public string CauseOfLoss { get; set; }
        public DateTime? DateOfLoss { get; set; }
    }
}


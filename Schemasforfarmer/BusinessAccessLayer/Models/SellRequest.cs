using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class SellRequest
    {
        public string CropType { get; set; }
        public string CropName { get; set; }
        public string FertilizerType { get; set; }
        public decimal? Quantity { get; set; }
        public string SoilPhCertificate { get; set; }
        public int? UserId { get; set; }
    }
}

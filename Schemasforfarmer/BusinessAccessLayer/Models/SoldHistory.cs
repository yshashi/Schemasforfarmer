using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class SoldHistory
    {
        public DateTime? Date { get; set; }
        public string CropName { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Msp { get; set; }
        public decimal? SolidPrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? UserId { get; set; }
    }
}

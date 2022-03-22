using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class WelcomePage
    {
        public string CropName { get; set; }
        public string CropType { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? CurrentBid { get; set; }
        public decimal? Bidammount { get; set; }
        public int? UserId { get; set; }
    }
}

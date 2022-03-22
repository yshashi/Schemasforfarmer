using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schemasforfarmer.Models
{
    public partial class PlaceSellRequest
    {
        [Key]
        public int Id { get; set; }
        public string CropType { get; set; }
        public string CropName { get; set; }
        public string FertilizerType { get; set; }
        public decimal? Quantity { get; set; }
        public string SoilPhCertificate { get; set; }
        public int? UserId { get; set; }

        public virtual UserInfo User { get; set; }
    }
}

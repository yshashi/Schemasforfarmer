using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Schemasforfarmer.Models
{
    public partial class CropType
    {
        public CropType()
        {
            Sell = new HashSet<Sell>();
        }

        [Key]
        public int CropTypeId { get; set; }
        public string CropTypeName { get; set; }

        public virtual ICollection<Sell> Sell { get; set; }
    }
}

using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class CropDetail
    {
        [Key]
        [Column("CropTypeId")]

        public int CropTypeId { get; set; }
        public string CropType1 { get; set; }

       

        

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class BankDetail
    {
        public int AccountNo { get; set; }
        public string Ifsccode { get; set; }
        public int Adhar { get; set; }
        public string Pan { get; set; }
        public string TraderLicense { get; set; }
        public int? UserId { get; set; }

    }
}

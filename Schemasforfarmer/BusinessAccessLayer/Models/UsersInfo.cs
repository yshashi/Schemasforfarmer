using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class UsersInfo
    {
      

        public string FullName { get; set; }
        public int ContactNo { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Pincode { get; set; }
        public string Password { get; set; }
        public string PermittedtoSale { get; set; }
        public int UserId { get; set; }
        public int? UserTypeId { get; set; }

        
        
    }
}

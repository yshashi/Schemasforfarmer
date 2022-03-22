using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class Login
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
        public int? UserId { get; set; }
        public int? UserTypeId { get; set; }
       
    }
}

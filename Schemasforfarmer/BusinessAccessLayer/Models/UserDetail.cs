using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.BusinessAccessLayer.Models
{
    public class UserDetail
    {
        public UserDetail()
        {
            UserInfo = new HashSet<UserInfo>();
        }

        public int UserTypeId { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}

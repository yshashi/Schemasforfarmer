using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface IUserDetail
    {
        List<UserDetail> GetUserDetail();

        UserDetail GetUserById(int id);
        int DeleteUserDetail(int id);
        bool InsertUserDetail(UserDetail user);
    }
}

using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface IUserInfo
    {
        List<UsersInfo> GetUserDetail();

        UsersInfo GetUserById(int id);
        int DeleteUser(int id);
        bool InsertUser(UsersInfo info);
    }
}

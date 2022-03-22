using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface ILoginInfo
    {
        List<Login> GetLoginDetails();

        Login GetinfoById(int id);
        int DeleteInfo(int id);
        bool InsertLoginDetail(Login login );
    }
}

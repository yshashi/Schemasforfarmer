using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface IWelcomePage
    {
        bool InsertWelcomePage(WelcomePage page);
        List<WelcomePage> GetAllWelcomePage();

        WelcomePage GetPageById(int id);
        int DeletePage(int id);
    }
}

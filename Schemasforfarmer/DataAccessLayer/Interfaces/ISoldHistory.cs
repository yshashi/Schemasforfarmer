using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface ISoldHistory
    {
        bool InsertSoldHistory(SoldHistory History);
        List<SoldHistory> GetAllSoldHistory();

        SoldHistory GetHistoryById(int id);
        int DeleteHistory(int id);
    }
}

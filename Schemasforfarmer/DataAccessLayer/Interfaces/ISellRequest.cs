using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface ISellRequest
    {
        bool InsertSellRequest(SellRequest sellRequest);
        List<SellRequest> GetAllSellRequest();

        SellRequest GetSellRequestById(int id);
        int DeleteRequest(int id);
    }
}

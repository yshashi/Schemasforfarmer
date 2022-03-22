using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface IMarketPlace
    {
        bool InsertMarketPlace(MarketPlace market);
        List<MarketPlace> GetAllMarketPlace();

        MarketPlace GetPlaceById(int id);
        int DeletePlace(int id);
    }
}

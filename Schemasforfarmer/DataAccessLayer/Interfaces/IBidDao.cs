using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface IBidDao
    {

        List<BidModel> GetBiddings();

        BidModel GetBidById(int id);
        int DeleteBid(int id);
        bool InsertBidder(BidModel bid);
    }
}

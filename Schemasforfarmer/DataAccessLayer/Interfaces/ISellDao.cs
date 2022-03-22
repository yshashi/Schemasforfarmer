using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;


namespace Schemasforfarmer.DataAccessLayer
{
    public  interface ISellDao
    {
        bool InsertSeller(Seller seller);
        List<Seller> GetSellers();

        Seller GetSellById(int id);
        int DeleteSell(int id);
    }
}

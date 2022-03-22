using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface IBankDetailsDao
    {
        bool InsertBankDetails(BankDetail bank);
        List<BankDetail> GetAllBankDetails();

        BankDetail GetBankDetailsById(int id);
        int DeleteBankDetails(int id);
    }
}

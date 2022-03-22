using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
    public interface IClaimInsuranceDao
    {

        bool InsertClaimHistory(ClaimInsuranceDetails History);
        List<ClaimInsuranceDetails> GetAllClaimHistory();

        ClaimInsuranceDetails GetClaimHistoryById(int id);
        int DeleteHistory(int id);
    }
}

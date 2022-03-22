using Schemasforfarmer.BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer.Interfaces
{
   public  interface IApplyforPolicyDao
    {
        bool InsertPolicyDetails(ApplyForPolicyDetail History);
        List<ApplyForPolicyDetail> GetAllApplyPolicyDetails();

        ApplyForPolicyDetail GetPolicyDetailsById(int no);
        int DeletePage(int no);
    }
}

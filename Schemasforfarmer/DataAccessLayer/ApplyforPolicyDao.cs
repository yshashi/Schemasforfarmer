using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Schemasforfarmer.BusinessAccessLayer.Models;
using Schemasforfarmer.DataAccessLayer.Interfaces;
using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer
{
    public class ApplyforPolicyDao :IApplyforPolicyDao
    {
        public bool InsertPolicyDetails(ApplyForPolicyDetail History)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ApplyForPolicy> allDetails = db.ApplyForPolicy;
                    ApplyForPolicy data = new ApplyForPolicy
                    {
                        Season = History.Season,
                        Year = History.Year,
                        CropName = History.CropName,
                        SumInsured = History.SumInsured,
                        Area = History.Area,
                        InsuranceCompany = History.InsuranceCompany,
                        SumInsuredperhect = History.SumInsuredperhect,
                        SharePremium = History.SharePremium,
                        PremiumAmount = History.PremiumAmount,
                        PolicyNo = History.PolicyNo,

                    };
                    allDetails.Add(data);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ApplyForPolicyDetail> GetAllApplyPolicyDetails()
        {
            List<ApplyForPolicyDetail> allPolicy = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ApplyForPolicy> allEntityPolicy = db.ApplyForPolicy;
                    allPolicy = allEntityPolicy
                     .Select((ApplyForPolicy History) =>
                 new ApplyForPolicyDetail
                 {
                     Season = History.Season,
                     Year = History.Year,
                     CropName = History.CropName,
                     SumInsured = History.SumInsured,
                     Area = History.Area,
                     InsuranceCompany = History.InsuranceCompany,
                     SumInsuredperhect = History.SumInsuredperhect,
                     SharePremium = History.SharePremium,
                     PremiumAmount = History.PremiumAmount,
                     PolicyNo = History.PolicyNo,
                 })
                     .ToList<ApplyForPolicyDetail>();
                }
                return allPolicy;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApplyForPolicyDetail GetPolicyDetailsById(int no)

        {
            ApplyForPolicyDetail number = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ApplyForPolicy> allEntityPolicy = db.ApplyForPolicy;
                    var matchingdetails = allEntityPolicy.Where(p => p.PolicyNo == no);
                    if (matchingdetails != null && matchingdetails.Count() > 0)
                    {
                        ApplyForPolicy p = matchingdetails.First<ApplyForPolicy>();
                        number = new ApplyForPolicyDetail
                        {
                            Season = p.Season,
                            Year = p.Year,
                            CropName = p.CropName,
                            SumInsured = p.SumInsured,
                            Area = p.Area,
                            InsuranceCompany = p.InsuranceCompany,
                            SumInsuredperhect = p.SumInsuredperhect,
                            SharePremium = p.SharePremium,
                            PremiumAmount = p.PremiumAmount,
                            PolicyNo = p.PolicyNo,
                        };
                    }
                }
                return number;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public int DeletePage(int no)
        {

            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ApplyForPolicy> viewPolicy = db.ApplyForPolicy;

                    ApplyForPolicy policy = viewPolicy.Where(p => p.PolicyNo == no).FirstOrDefault();
                    viewPolicy.Remove(policy);
                    int rawAffected = db.SaveChanges();
                    return rawAffected;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

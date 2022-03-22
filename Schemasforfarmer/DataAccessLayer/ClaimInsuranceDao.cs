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
    public class ClaimInsuranceDao :IClaimInsuranceDao
    {
        public bool InsertClaimHistory(ClaimInsuranceDetails History)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ClaimInsurance> allData = db.ClaimInsurance;
                    ClaimInsurance history = new ClaimInsurance
                    {
                        ParticularsOfInsuree = History.ParticularsOfInsuree,
                        PolicyNo = History.PolicyNo,
                        InsuranceCompany = History.InsuranceCompany,
                        NameOfInsuree = History.NameOfInsuree,
                        SumInsured = History.SumInsured,
                        CauseOfLoss = History.CauseOfLoss,
                        DateOfLoss = History.DateOfLoss,


                    };
                    allData.Add(history);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ClaimInsuranceDetails> GetAllClaimHistory()
        {
            List<ClaimInsuranceDetails> allClaimPolicies = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ClaimInsurance> allEntityCrops = db.ClaimInsurance;
                    allClaimPolicies = allEntityCrops
                      .Select(History =>
                  new ClaimInsuranceDetails
                  {
                      ParticularsOfInsuree = History.ParticularsOfInsuree,
                      PolicyNo = History.PolicyNo,
                      InsuranceCompany = History.InsuranceCompany,
                      NameOfInsuree = History.NameOfInsuree,
                      SumInsured = History.SumInsured,
                      CauseOfLoss = History.CauseOfLoss,
                      DateOfLoss = History.DateOfLoss,
                  })
                      .ToList();
                }
                return allClaimPolicies;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ClaimInsuranceDetails GetClaimHistoryById(int id)

        {

            ClaimInsuranceDetails claim = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ClaimInsurance> allClaimHistory = db.ClaimInsurance;
                    var matchingData = allClaimHistory.Where(p => p.PolicyNo == id);
                    if (matchingData != null && matchingData.Count() > 0)
                    {
                        ClaimInsurance p = matchingData.First<ClaimInsurance>();
                        claim = new ClaimInsuranceDetails
                        {
                            ParticularsOfInsuree = p.ParticularsOfInsuree,
                            PolicyNo = p.PolicyNo,
                            InsuranceCompany = p.InsuranceCompany,
                            NameOfInsuree = p.NameOfInsuree,
                            SumInsured = p.SumInsured,
                            CauseOfLoss = p.CauseOfLoss,
                            DateOfLoss = p.DateOfLoss,
                        };
                    }
                }
                return claim;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public int DeleteHistory(int id)
        {

            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ClaimInsurance> viewClaimData = db.ClaimInsurance;

                    ClaimInsurance claim = viewClaimData.Where(p => p.PolicyNo == id).FirstOrDefault();
                    viewClaimData.Remove(claim);
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

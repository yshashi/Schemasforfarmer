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
    public class BankDetailsDao:IBankDetailsDao
    {
        public bool InsertBankDetails(BankDetail bank)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BankDetails> alldetails = db.BankDetails;
                    BankDetails bankData = new BankDetails
                    {
                        AccountNo = bank.AccountNo,
                        Ifsccode = bank.Ifsccode,
                        Adhar = bank.Adhar,
                        Pan = bank.Pan,
                        TraderLicense = bank.TraderLicense,
                        UserId = bank.UserId

                    };
                    alldetails.Add(bankData);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BankDetail> GetAllBankDetails()
        {
            List<BankDetail> allBankData = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BankDetails> allBankDeatils = db.BankDetails;
                    allBankData = allBankDeatils
                      .Select(bankData =>
                  new BankDetail
                  {
                      AccountNo = bankData.AccountNo,
                      Ifsccode = bankData.Ifsccode,
                      Adhar = bankData.Adhar,
                      Pan = bankData.Pan,
                      TraderLicense = bankData.TraderLicense,
                      UserId = bankData.UserId
                  })
                      .ToList();
                }
                return allBankData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public BankDetail GetBankDetailsById(int id)

        {

            BankDetail bankDetail = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BankDetails> allBankDeatils = db.BankDetails;
                    var matchingAccount = allBankDeatils.Where(p => p.UserId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        BankDetails p = matchingAccount.First<BankDetails>();
                        bankDetail = new BankDetail
                        {
                            AccountNo = p.AccountNo,
                            Ifsccode = p.Ifsccode,
                            Adhar = p.Adhar,
                            Pan = p.Pan,
                            TraderLicense = p.TraderLicense,
                            UserId = p.UserId
                        };
                    }
                }
                return bankDetail;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public int DeleteBankDetails(int id)
        {

            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BankDetails> bankData = db.BankDetails;

                    BankDetails bank = bankData.Where(p => p.UserId == id).FirstOrDefault();
                    bankData.Remove(bank);
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

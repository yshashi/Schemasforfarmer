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
    public class SoldHistoryDao :ISoldHistory
    {
        public bool InsertSoldHistory(SoldHistory History)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewSoldCropHistory> allHistory = db.ViewSoldCropHistory;
                    ViewSoldCropHistory history = new ViewSoldCropHistory
                    {
                        CropName=History.CropName,
                        Date=History.Date,
                        Quantity=History.Quantity,
                        Msp=History.Msp,
                        SolidPrice=History.SolidPrice,
                        TotalPrice=History.TotalPrice,
                        UserId=History.UserId


                    };
                    allHistory.Add(history);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SoldHistory> GetAllSoldHistory()
        {
            List<SoldHistory> allCrops = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewSoldCropHistory> allEntityCrops = db.ViewSoldCropHistory;
                    allCrops = allEntityCrops
                      .Select(History =>
                  new SoldHistory
                  {
                      CropName = History.CropName,
                      Date = History.Date,
                      Quantity = History.Quantity,
                      Msp = History.Msp,
                      SolidPrice = History.SolidPrice,
                      TotalPrice = History.TotalPrice,
                      UserId = History.UserId
                  })
                      .ToList();
                }
                return allCrops;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SoldHistory GetHistoryById(int id)

        {

            SoldHistory sold= null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewSoldCropHistory> allEntitysolds = db.ViewSoldCropHistory;
                    var matchingAccount = allEntitysolds.Where(p => p.UserId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        ViewSoldCropHistory p = matchingAccount.First<ViewSoldCropHistory>();
                        sold= new SoldHistory
                        {
                            CropName = p.CropName,
                            Date = p.Date,
                            Quantity = p.Quantity,
                            Msp = p.Msp,
                            SolidPrice = p.SolidPrice,
                            TotalPrice = p.TotalPrice,
                            UserId =p.UserId
                        };
                    }
                }
                return sold;
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
                    DbSet<ViewSoldCropHistory> viewSolds = db.ViewSoldCropHistory;

                    ViewSoldCropHistory sold = viewSolds.Where(p => p.UserId == id).FirstOrDefault();
                    viewSolds.Remove(sold);
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

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Schemasforfarmer.BusinessAccessLayer.Models;
using Schemasforfarmer.DataAccessLayer;
using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.DataAccessLayer
{
    public class SellDao :ISellDao
    {

        public List<Seller> GetSellers()
        {
            List<Seller> allseller = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<Sell> allEntityCrops = db.Sell;
                    allseller = allEntityCrops
                      .Select(seller =>
                  new Seller
                  {
                      
                      SellId = seller.SellId,
                      BasePrice = seller.BasePrice,
                     Bidding=seller.Bidding,
                     CropType=seller.CropType,
                      CropTypeId = seller.CropTypeId,
                      CropName = seller.CropName,
                      UserId = seller.UserId,
                      Quantity = seller.Quantity,
                      FertilizerType = seller.FertilizerType,
                      
                      
                     
                  })
                      .ToList();
                }
                return allseller;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        

        public bool InsertSeller(Seller seller)
        {
            int result = 0;
            try
            {
                using var db = new AgricultureContext();
                {
                    DbSet<Sell> allcrop = db.Sell;
                    Sell entityobj = new Sell
                    {
                        SellId = seller.SellId,
                        BasePrice=seller.BasePrice,
                        
                     
                        CropTypeId=seller.CropTypeId,
                        CropName=seller.CropName,
                        UserId=seller.UserId,
                        Quantity=seller.Quantity,
                        FertilizerType=seller.FertilizerType,
                       



                    };
                    allcrop.Add(entityobj);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Seller GetSellById(int id)

        {

            Seller seller = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<Sell> allEntityCrops = db.Sell;
                    var matchingAccount = allEntityCrops.Where(p => p.SellId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        Sell p = matchingAccount.First<Sell>();
                        seller = new Seller
                        {
                            SellId = p.SellId,
                            BasePrice = p.BasePrice,


                            CropTypeId = p.CropTypeId,
                            CropName = p.CropName,
                            UserId = p.UserId,
                            Quantity = p.Quantity,
                            FertilizerType = p.FertilizerType,
                        };
                    }
                }
                return seller;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public int DeleteSell(int id)
        {
            
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<Sell> sellz = db.Sell;

                    Sell sell1 = sellz.Where(p => p.CropTypeId == id).FirstOrDefault();
                    sellz.Remove(sell1);
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

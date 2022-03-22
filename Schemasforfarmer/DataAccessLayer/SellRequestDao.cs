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
    public class SellRequestDao :ISellRequest
    {
        public bool InsertSellRequest(SellRequest sellRequest)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<PlaceSellRequest> allreq = db.PlaceSellRequest;
                    PlaceSellRequest place = new PlaceSellRequest
                    {
                        CropName=sellRequest.CropName,
                        CropType=sellRequest.CropType,
                        FertilizerType=sellRequest.FertilizerType,
                        Quantity=sellRequest.Quantity,
                        SoilPhCertificate=sellRequest.SoilPhCertificate,
                        UserId=sellRequest.UserId

                    };
                    allreq.Add(place);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SellRequest> GetAllSellRequest()
        {
            List<SellRequest> allReq = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<PlaceSellRequest> allEntityRequest = db.PlaceSellRequest;
                    allReq = allEntityRequest
                      .Select(sellRequest =>
                  new SellRequest
                  {
                      CropName = sellRequest.CropName,
                      CropType = sellRequest.CropType,
                      FertilizerType = sellRequest.FertilizerType,
                      Quantity = sellRequest.Quantity,
                      SoilPhCertificate = sellRequest.SoilPhCertificate,
                      UserId = sellRequest.UserId
                  })
                      .ToList();
                }
                return allReq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SellRequest GetSellRequestById(int id)

        {

            SellRequest sellRequest = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<PlaceSellRequest> allEntityReq = db.PlaceSellRequest;
                    var matchingAccount = allEntityReq.Where(p => p.UserId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        PlaceSellRequest p = matchingAccount.First<PlaceSellRequest>();
                        sellRequest = new SellRequest
                        {
                            CropName = p.CropName,
                            CropType = p.CropType,
                            FertilizerType = p.FertilizerType,
                            Quantity = p.Quantity,
                            SoilPhCertificate = p.SoilPhCertificate,
                            UserId = p.UserId
                        };
                    }
                }
                return sellRequest;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public int DeleteRequest(int id)
        {

            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<PlaceSellRequest> placeSell = db.PlaceSellRequest;

                    PlaceSellRequest place =placeSell.Where(p => p.UserId == id).FirstOrDefault();
                    placeSell.Remove(place);
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

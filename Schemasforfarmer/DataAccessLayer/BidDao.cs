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
    public class BidDao : IBidDao
    {

        public List<BidModel> GetBiddings()
        {
            List<BidModel> allBids = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<Bidding> allEntityBids = db.Bidding;
                    allBids = allEntityBids
                      .Select(entityCrop =>
                  new BidModel
                  {
                      BiddingId=entityCrop.BiddingId,
                      BidAmt=entityCrop.BidAmt,
                      BidDate=entityCrop.BidDate,
                      IsBitStatus=entityCrop.IsBitStatus,
                     Sell=entityCrop.Sell,
                      SellId=entityCrop.SellId,
                      
                      
                      UserId=entityCrop.UserId
                  })
                      .ToList();
                }
                return allBids;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public BidModel GetBidById(int id)

        {
            BidModel bid = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<Bidding> allEntityCrops = db.Bidding;
                    var matchingAccount = allEntityCrops.Where(p => p.BiddingId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        Bidding p = matchingAccount.First();
                        bid = new BidModel
                        {
                            BiddingId= p.BiddingId,
                            BidAmt= p.BidAmt,
                            BidDate= p.BidDate,
                            IsBitStatus= p.IsBitStatus,
                            UserId= p.UserId,
                            SellId= p.SellId
                           
                        };
                    }
                }
                return bid;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public bool InsertBidder(BidModel p)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<Bidding> allbid = db.Bidding;
                    Bidding bid = new Bidding
                    {
                        BiddingId = p.BiddingId,
                        BidAmt = p.BidAmt,
                        BidDate = p.BidDate,
                        IsBitStatus = p.IsBitStatus,
                        UserId = p.UserId,
                        SellId = p.SellId



                    };
                    allbid.Add(bid);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteBid(int id)
        {
           
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<Bidding> bidding = db.Bidding;

                    Bidding bid = bidding.Where(p => p.BiddingId == id).FirstOrDefault();
                    bidding.Remove(bid);
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

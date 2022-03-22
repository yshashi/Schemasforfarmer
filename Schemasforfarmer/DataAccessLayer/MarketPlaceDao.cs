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
    public class MarketPlaceDao :IMarketPlace
    {
        public bool InsertMarketPlace(MarketPlace market)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewMarketPlace> allplace = db.ViewMarketPlace;
                    ViewMarketPlace place = new ViewMarketPlace
                    {
                       UserId=market.UserId,
                       CropName=market.CropName,
                       CropType=market.CropType,
                       BasePrice=market.BasePrice,
                       CurrentBid=market.CurrentBid


                    };
                    allplace.Add(place);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<MarketPlace> GetAllMarketPlace()
        {
            List<MarketPlace> allPlaces = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewMarketPlace> allEntityCrops = db.ViewMarketPlace;
                    allPlaces = allEntityCrops
                      .Select(market =>
                  new MarketPlace
                  {
                      UserId = market.UserId,
                      CropName = market.CropName,
                      CropType = market.CropType,
                      BasePrice = market.BasePrice,
                      CurrentBid = market.CurrentBid

                  })
                      .ToList();
                }
                return allPlaces;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MarketPlace GetPlaceById(int id)

        {

            MarketPlace market = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewMarketPlace> allEntityplaces = db.ViewMarketPlace;
                    var matchingAccount = allEntityplaces.Where(p => p.UserId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        ViewMarketPlace p = matchingAccount.FirstOrDefault<ViewMarketPlace>();
                        market = new MarketPlace
                        {
                            UserId = p.UserId,
                            CropName = p.CropName,
                            CropType = p.CropType,
                            BasePrice = p.BasePrice,
                            CurrentBid = p.CurrentBid
                        };
                    }
                }
                return market;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public int DeletePlace(int id)
        {

            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<ViewMarketPlace> place = db.ViewMarketPlace;

                    ViewMarketPlace marketPlace = place.Where(p => p.UserId == id).FirstOrDefault();
                    place.Remove(marketPlace);
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

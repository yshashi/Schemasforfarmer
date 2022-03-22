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
    public class WelcomePageDao :IWelcomePage
    {
        public bool InsertWelcomePage(WelcomePage page)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BidderWelcomePage> allpage = db.BidderWelcomePage;
                    BidderWelcomePage welcomePage = new BidderWelcomePage
                    {
                       
                        Bidammount=page.Bidammount,
                        UserId=page.UserId,
                        CropName=page.CropName,
                        CropType=page.CropType,
                        CurrentBid=page.CurrentBid,
                        BasePrice = page.BasePrice


                    };
                    allpage.Add(welcomePage);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<WelcomePage> GetAllWelcomePage()
        {
            List<WelcomePage> allPages = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BidderWelcomePage> allEntitypages = db.BidderWelcomePage;
                    allPages = allEntitypages
                      .Select(entitypage =>
                  new WelcomePage
                  {
                      Bidammount = entitypage.Bidammount,
                      UserId = entitypage.UserId,
                      CropName = entitypage.CropName,
                      CropType = entitypage.CropType,
                      CurrentBid = entitypage.CurrentBid,
                      BasePrice = entitypage.BasePrice
                  })
                      .ToList();
                }
                return allPages;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public WelcomePage GetPageById(int id)

        {

             WelcomePage page = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BidderWelcomePage> allEntityPages = db.BidderWelcomePage;
                    var matchingAccount = allEntityPages.Where(p => p.UserId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)
                    {
                        BidderWelcomePage p = matchingAccount.First<BidderWelcomePage>();
                        page = new WelcomePage
                        {
                            Bidammount = p.Bidammount,
                            UserId = p.UserId,
                            CropName =p .CropName,
                            CropType = p.CropType,
                            CurrentBid =p .CurrentBid,
                            BasePrice = p.BasePrice
                        };
                    }
                }
                return page;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public int DeletePage(int id)
        {

            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<BidderWelcomePage> pages = db.BidderWelcomePage;

                   BidderWelcomePage page = pages.Where(p => p.UserId == id).FirstOrDefault();
                    pages.Remove(page);
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

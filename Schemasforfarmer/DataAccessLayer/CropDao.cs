using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Schemasforfarmer.BusinessAccessLayer.Models;
using Schemasforfarmer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Schemasforfarmer.DataAccessLayer
{
    public class CropDao : ICropDao
    {
        public bool InsertCrop(CropDetail crop)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<CropType> allcrop = db.CropType;
                    CropType cropType = new CropType
                    {
                        CropTypeId = crop.CropTypeId,
                        CropTypeName = crop.CropType1


                    };
                    allcrop.Add(cropType);
                    result = db.SaveChanges();
                }
                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CropDetail> GetAllCrops()
        {
            List<CropDetail> allCrops = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<CropType> allEntityCrops = db.CropType;
                    allCrops = allEntityCrops
                      .Select(entityCrop =>
                  new CropDetail
                  {
                      CropType1 = entityCrop.CropTypeName,
                      CropTypeId = entityCrop.CropTypeId
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

        public CropDetail GetCropById(int id)

        {

            CropDetail cropDetail = null;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<CropType> allEntityCrops = db.CropType;
                    var matchingcrop = allEntityCrops.Where(p => p.CropTypeId == id);
                    if (matchingcrop != null && matchingcrop.Count() > 0)
                    {
                        CropType p = matchingcrop.First<CropType>();
                        cropDetail = new CropDetail
                        {
                            CropType1 = p.CropTypeName,
                            CropTypeId = p.CropTypeId
                        };
                    }
                }
                return cropDetail;
            }
            catch (Exception ex)

            {
                throw ex;
            }

        }
        public bool UpdateCrop(CropDetail p,int id)
        {
            int result = 0;
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<CropType> allCrops = db.CropType;
                    var matchingAccount = allCrops.Where(p => p.CropTypeId == id);
                    if (matchingAccount != null && matchingAccount.Count() > 0)


                        
                    {
                        CropType a = matchingAccount.First<CropType>();
                        a.CropTypeName = p.CropType1;

                        allCrops.Update(a);
                        result = db.SaveChanges();
                    }
                   
                }
                return result > 0;
            }
            catch(Exception ex)
            {
                throw ex;
            }
         }
        public bool DeleteCrop(int id)
        {
            int res = 0;
            
            try
            {
                using (var db = new AgricultureContext())
                {
                    DbSet<CropType> allEntityCrops = db.CropType;

                    var matchingcrop = allEntityCrops.Where(p => p.CropTypeId == id);
                    if (matchingcrop != null && matchingcrop.Count() > 0)
                    {
                        CropType p = matchingcrop.First<CropType>();
                        allEntityCrops.Remove(p);
                        res = db.SaveChanges();
                    }

                }
                return res > 0;
            }
            
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}








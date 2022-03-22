using Schemasforfarmer.BusinessAccessLayer.Models;
using System.Collections.Generic;

namespace Schemasforfarmer.DataAccessLayer
{
    public interface ICropDao
    {
        bool InsertCrop(CropDetail crop);
        List<CropDetail> GetAllCrops();

        CropDetail GetCropById(int id);
        bool UpdateCrop(CropDetail p,int id);
       bool DeleteCrop(int id);
    }
}
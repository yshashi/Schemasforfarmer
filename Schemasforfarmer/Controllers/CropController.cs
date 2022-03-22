using Microsoft.AspNetCore.Mvc;
using Schemasforfarmer.BusinessAccessLayer.Models;
using Schemasforfarmer.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CropController : Controller
    {


        private ICropDao _cropDao;
        public CropController(ICropDao cropDao)
        {

            this._cropDao = cropDao;
        }

        [HttpGet]

        [Route("allcrops")]
        public IActionResult FetchCrops()
        {
            try
            {

                return this.Ok(_cropDao.GetAllCrops());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]



        public IActionResult FetchCropById(int id)
        {
            try
            {

                return this.Ok(_cropDao.GetCropById(id));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddCrop")]
        public IActionResult AddCrop(CropDetail crop)
        {
            var result = _cropDao.InsertCrop(crop);
            return this.CreatedAtAction(
                "InsertSeller",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = crop
                }
                );
        }
        [HttpPut]
        [Route("UpdateCrop")]
        public IActionResult UpdateCrop(CropDetail p,int id)
        {
            var result = _cropDao.UpdateCrop(p,id
                );
            return this.CreatedAtAction(
                "UpdateCrop",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = p
                }
                );
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCrop(int id)
        {
            try
            {
                var result = _cropDao.DeleteCrop(id
                  );
                return this.CreatedAtAction(
                  "DeleteCrop",
                  new
                  {
                      StatusCode = 201,
                      Response = result,
                      Data = id
                  }
                  );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
                    
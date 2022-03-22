using Microsoft.AspNetCore.Mvc;
using Schemasforfarmer.BusinessAccessLayer.Models;
using Schemasforfarmer.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketplaceController : Controller
    {
        private IMarketPlace _placeDao;
        public MarketplaceController(IMarketPlace placeDao)
        {

            this._placeDao = placeDao;
        }

        [HttpGet]

        [Route("allplaces")]
        public IActionResult Fetchplaces()
        {
            try
            {

                return this.Ok(_placeDao.GetAllMarketPlace());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("fetchbyid")]



        public IActionResult FetchCropById(int id)
        {
            try
            {

                return this.Ok(_placeDao.GetPlaceById(id));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertCrop")]
        public IActionResult InsertMarketPlace(MarketPlace market)
        {
            var result = _placeDao.InsertMarketPlace(market
                );
            return this.CreatedAtAction(
                "InsertCrop",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = market
                }
                );
        }
        [HttpDelete]
        [Route("id")]
        public IActionResult DeletePlace(int id)
        {
            try
            {
                var result = _placeDao.DeletePlace(id
                  );
                return this.CreatedAtAction(
                  "DeletePlace",
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

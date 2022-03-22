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
    public class SellerController : Controller
    {


        private ISellDao _sellDao;
        public SellerController(ISellDao sellDao)
        {

            this._sellDao = sellDao;
        }
        [HttpGet]
        [Route("sell")]
        public IActionResult FetchCrops()
        {
            try
            {

                return this.Ok(_sellDao.GetSellers());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("AddSell")]
        public IActionResult AddSeller(Seller seller)
        {
            var result = _sellDao.InsertSeller(seller);
            return this.CreatedAtAction(
                "InsertSeller",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = seller
                }
                );
        }
        [HttpGet]
        [Route("fetchbyid")]



        public IActionResult FetchsellById(int id)
        {
            try
            {

                return this.Ok(_sellDao.GetSellById(id));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("id")]
        public IActionResult DeleteCrop(int id)
        {
            try
            {
                var result = _sellDao.DeleteSell(id
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

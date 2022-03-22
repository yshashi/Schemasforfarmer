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
    public class SellRequestController : Controller
    {
        private ISellRequest _sellDao;
        public SellRequestController(ISellRequest sellDao)
        {

            this._sellDao = sellDao;
        }

        [HttpGet]

        [Route("allRequest")]
        public IActionResult FetchRequest()
        {
            try
            {

                return this.Ok(_sellDao.GetAllSellRequest());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("fetchbyid")]



        public IActionResult FetchSellById(int id)
        {
            try
            {

                return this.Ok(_sellDao.GetSellRequestById(id));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertRequest")]
        public IActionResult InsertRequest(SellRequest sellrequest)
        {
            var result = _sellDao.InsertSellRequest(sellrequest
                );
            return this.CreatedAtAction(
                "InsertRequest",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = sellrequest
                }
                );
        }
        [HttpDelete]
        [Route("id")]
        public IActionResult DeleteRequest(int id)
        {
            try
            {
                var result = _sellDao.DeleteRequest(id
                  );
                return this.CreatedAtAction(
                  "DeleteRequest",
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

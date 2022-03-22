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
    public class SoldHistoryController : Controller
    {


        private ISoldHistory _soldDao;
        public SoldHistoryController(ISoldHistory soldDao)
        {

            this._soldDao = soldDao;
        }

        [HttpGet]

        [Route("allsolds")]
        public IActionResult FetchSoldHistory()
        {
            try
            {

                return this.Ok(_soldDao.GetAllSoldHistory());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]



        public IActionResult FetchSoldById(int id)
        {
            try
            {

                return this.Ok(_soldDao.GetHistoryById(id));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertSoldHistory")]
        public IActionResult InsertSoldHistory(SoldHistory History)
        {
            var result = _soldDao.InsertSoldHistory(History
                );
            return this.CreatedAtAction(
                "InsertSoldHistory",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = History
                }
                );
        }
        [HttpDelete]
        [Route("id")]
        public IActionResult DeleteHistory(int id)
        {
            try
            {
                var result = _soldDao.DeleteHistory(id
                  );
                return this.CreatedAtAction(
                  "DeleteHistory",
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

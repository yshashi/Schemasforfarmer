using Microsoft.AspNetCore.Mvc;
using Schemasforfarmer.BusinessAccessLayer.Models;
using Schemasforfarmer.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.Controllers
{
    [Route("api/allbids")]
    [ApiController]
    public class BiddingController : Controller
    {


        private IBidDao _bidDao;
        public BiddingController(IBidDao bidDao)
        {

            this._bidDao = bidDao;
        }

        [HttpGet]


        public IActionResult FetchBids()
        {
            try
            {

                return this.Ok(_bidDao.GetBiddings());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("{id}")]



        public IActionResult FetchBidById(int id)
        {
            try
            {

                return this.Ok(_bidDao.GetBidById(id));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("InsertBid")]
        public IActionResult Insertbid(BidModel Bid
            )
        {
            var result = _bidDao.InsertBidder(Bid
                );
            return this.CreatedAtAction(
                "InsertCrop",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = Bid
                }
                );
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteBid(int id)
        {
            try
            {
                var result = _bidDao.DeleteBid(id
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

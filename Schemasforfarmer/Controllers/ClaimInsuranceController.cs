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
    public class ClaimInsuranceController : Controller
    {
        private IClaimInsuranceDao _claimDao;

        public ClaimInsuranceController(IClaimInsuranceDao claimDao)
        {

            this._claimDao = claimDao;
        }

        [HttpGet]

        [Route("allclaimhistory")]
        public IActionResult FetchClaimdHistory()
        {
            try
            {

                return this.Ok(_claimDao.GetAllClaimHistory());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("fetchbyid")]

        public IActionResult FetchSoldById(int id)
        {
            try
            {

                return this.Ok(_claimDao.GetClaimHistoryById(id));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertClaimHistory")]
        public IActionResult InsertSoldHistory(ClaimInsuranceDetails Details)
        {
            var result = _claimDao.InsertClaimHistory(Details
                );
            return this.CreatedAtAction(
                "InsertclaimHistory",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = Details
                }
                );
        }
        [HttpDelete]
        [Route("id")]
        public IActionResult DeleteHistory(int id)
        {
            try
            {
                var result = _claimDao.DeleteHistory(id
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

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
    public class ApplyForPolicyController : Controller
    {
        private IApplyforPolicyDao _policyDao;
        public ApplyForPolicyController(IApplyforPolicyDao policyDao)
        {

            this._policyDao = policyDao;
        }

        [HttpGet]

        [Route("allpolicies")]
        public IActionResult FetchPolicyHistory()
        {
            try
            {

                return this.Ok(_policyDao.GetAllApplyPolicyDetails());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("fetchbyid")]



        public IActionResult FetchPolicyById(int no)
        {
            try
            {

                return this.Ok(_policyDao.GetPolicyDetailsById(no));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("{InsertSoldHistory}")]
        public IActionResult InsertPolicyDetails(ApplyForPolicyDetail History)
        {
            var result = _policyDao.InsertPolicyDetails(History);
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
        public IActionResult DeletePage(int no)
        {
            try
            {
                var result = _policyDao.DeletePage(no
                  );
                return this.CreatedAtAction(
                  "DeleteHistory",
                  new
                  {
                      StatusCode = 201,
                      Response = result,
                      Data = no
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


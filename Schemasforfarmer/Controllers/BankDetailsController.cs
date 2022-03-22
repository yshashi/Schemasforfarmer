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
    public class BankDetailsController : Controller
    {
        private IBankDetailsDao _bankDao;

        public BankDetailsController(IBankDetailsDao bankDao)
        {

            this._bankDao = bankDao;
        }
        [HttpGet]

        [Route("allcrops")]
        public IActionResult FetchBankDetails()
        {
            try
            {

                return this.Ok(_bankDao.GetAllBankDetails());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("fetchbyid")]



        public IActionResult FetchBankById(int id)
        {
            try
            {

                return this.Ok(_bankDao.GetBankDetailsById(id));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertBankDetails")]
        public IActionResult InsertBankDetails(BankDetail crop)
        {
            var result = _bankDao.InsertBankDetails(crop
                );
            return this.CreatedAtAction(
                "InsertCrop",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = crop
                }
                );
        }
        [HttpDelete]
        [Route("id")]
        public IActionResult DeleteBankDetails(int id)
        {
            try
            {
                var result = _bankDao.DeleteBankDetails(id
                  );
                return this.CreatedAtAction(
                  "DeleteBankDetails",
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

using Microsoft.AspNetCore.Mvc;
using Schemasforfarmer.BusinessAccessLayer.Models;
using Schemasforfarmer.DataAccessLayer;
using Schemasforfarmer.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WelcomePageController : Controller
    {
        private IWelcomePage _pageDao;
        public WelcomePageController(IWelcomePage pageDao)
        {

            this._pageDao = pageDao;
        }

        [HttpGet]

        [Route("allpages")]
        public IActionResult FetchPages()
        {
            try
            {

                return this.Ok(_pageDao.GetAllWelcomePage());
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("fetchbyid")]



        public IActionResult FetchPageById(int id)
        {
            try
            {

                return this.Ok(_pageDao.GetPageById(id));
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("InsertPage")]
        public IActionResult InsertWelcomePage(WelcomePage page)
        {
            var result = _pageDao.InsertWelcomePage(page
                );
            return this.CreatedAtAction(
                "InsertWelcomePage",
                new
                {
                    StatusCode = 201,
                    Response = result,
                    Data = page
                }
                );
        }
        [HttpDelete]
        [Route("id")]
        public IActionResult DeletePage(int id)
        {
            try
            {
                var result = _pageDao.DeletePage(id
                  );
                return this.CreatedAtAction(
                  "DeletePage",
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


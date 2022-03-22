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
    public class LoginController : Controller
    {
            private ILoginInfo _loginDao;
            
            public LoginController(ILoginInfo loginInfo)
            {
            this._loginDao = loginInfo;
            }
            [HttpGet]

            [Route("allLogins")]
            public IActionResult FetchLogin()
            {
                try
                {

                    return this.Ok(_loginDao.GetLoginDetails());
                }
                catch (Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
            }
            [HttpGet]
            [Route("fetchbyid")]



            public IActionResult FetchLoginById(int id)
            {
                try
                {

                    return this.Ok(_loginDao.GetinfoById(id));
                }
                catch (Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
            }

            [HttpPost]
            [Route("InsertCrop")]
            public IActionResult InsertLogin(Login login)
            {
                var result = _loginDao.InsertLoginDetail(login
                    );
                return this.CreatedAtAction(
                    "InsertCrop",
                    new
                    {
                        StatusCode = 201,
                        Response = result,
                        Data = login
                    }
                    );
            }
        [HttpDelete]
        [Route("id")]
        public IActionResult DeleteLogin(int id)
        {
            try
            {
                var result = _loginDao.DeleteInfo(id
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

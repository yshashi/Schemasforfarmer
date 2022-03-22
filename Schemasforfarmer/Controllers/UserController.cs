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
    public class UserController : Controller
    {
        
        


            private IUserDetail _detailDao;
            public UserController(IUserDetail detailDao)
            {

                this._detailDao = detailDao;
            }

            [HttpGet]

            [Route("alluserdetails")]
            public IActionResult FetchUserDetails()
            {
                try
                {

                    return this.Ok(_detailDao.GetUserDetail());
                }
                catch (Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
            }
            [HttpGet]
            [Route("fetchbyid")]



            public IActionResult FetchUserById(int id)
            {
                try
                {

                    return this.Ok(_detailDao.GetUserById(id));
                }
                catch (Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
            }

            [HttpPost]
            [Route("InsertUserDetail")]
            public IActionResult InsertUserDetail(UserDetail details)
            {
                var result = _detailDao.InsertUserDetail(details
                    );
                return this.CreatedAtAction(
                    "InsertUserDetails",
                    new
                    {
                        StatusCode = 201,
                        Response = result,
                        Data = details
                    }
                    );
            }
            [HttpDelete]
            [Route("id")]
            public IActionResult DeleteDetails(int id)
            {
                try
                {
                    var result = _detailDao.DeleteUserDetail(id
                      );
                    return this.CreatedAtAction(
                      "DeleteUserDetail",
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

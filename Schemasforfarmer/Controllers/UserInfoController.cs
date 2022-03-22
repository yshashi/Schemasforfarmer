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
    public class UserInfoController : Controller
    {
       
       


            private IUserInfo _userDao;
            public UserInfoController(IUserInfo userDao)
            {

                this._userDao = userDao;
            }

            [HttpGet]

            [Route("allusers")]
            public IActionResult FetchUsers()
            {
                try
                {

                    return this.Ok(_userDao.GetUserDetail());
                }
                catch (Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
            }
            [HttpGet]
            [Route("fetchbyid")]



            public IActionResult FetchCropById(int id)
            {
                try
                {

                    return this.Ok(_userDao.GetUserById(id));
                }
                catch (Exception ex)
                {
                    return this.BadRequest(ex.Message);
                }
            }

            [HttpPost]
            [Route("InsertCrop")]
            public IActionResult InsertUser(UsersInfo info)
            {
                var result = _userDao.InsertUser(info
                    );
                return this.CreatedAtAction(
                    "InsertUser",
                    new
                    {
                        StatusCode = 201,
                        Response = result,
                        Data = info
                    }
                    );
            }
            [HttpDelete]
            [Route("id")]
            public IActionResult DeleteUSer(int id)
            {
                try
                {
                    var result = _userDao.DeleteUser(id
                      );
                    return this.CreatedAtAction(
                      "DeleteUser",
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

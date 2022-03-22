using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schemasforfarmer.Dtos;
using Schemasforfarmer.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Schemasforfarmer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AgricultureContext _context;
        public AuthController(AgricultureContext context)
        {
            _context = context;
        }
        [HttpPost("register-farmer")]
        public async Task<ActionResult<FarmerDetailsModel>> RegisterFarmer([FromBody] FarmerDetailsModel farmerDetailsModel)
        {
            if (farmerDetailsModel == null)
            {
                return BadRequest();
            }
            
            var userInfo = new UserInfo
            {
                FullName = farmerDetailsModel.FarmerFullName,
                ContactNo= Convert.ToInt32(farmerDetailsModel.FarmerContact),
                EmailId=farmerDetailsModel.FarmerEmail,
                Address=farmerDetailsModel.FarmerAddress,
                City=farmerDetailsModel.FarmerCity,
                State=farmerDetailsModel.FarmerState,
                Pincode = farmerDetailsModel.FarmerLandPincode,
                Password=farmerDetailsModel.FarmerPassword,
                PermittedtoSale="Yes",
                UserTypeId = 3

            };
            await _context.UserInfo.AddAsync(userInfo);
            await _context.FarmerDetailsModels.AddAsync(farmerDetailsModel);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Farmer Register Successfully!"
            });
        }
        [HttpPost("register-bidder")]
        public async Task<ActionResult<BidderDetailsModel>> RegisterBidder([FromBody] BidderDetailsModel bidderDetailsModel)
        {
            if (bidderDetailsModel == null)
            {
                return BadRequest();
            }
            var userInfo = new UserInfo
            {
                FullName = bidderDetailsModel.BidderFullName,
                ContactNo = Convert.ToInt32(bidderDetailsModel.BidderContact),
                EmailId = bidderDetailsModel.BidderEmail,
                Address = bidderDetailsModel.BidderAddress,
                City = bidderDetailsModel.BidderCity,
                State = bidderDetailsModel.BidderState,
                Pincode = bidderDetailsModel.BidderPincode,
                Password = bidderDetailsModel.BidderPassword,
                PermittedtoSale = "Yes",
                UserTypeId = 2

            };
            await _context.UserInfo.AddAsync(userInfo);
            await _context.BidderDetailsModels.AddAsync(bidderDetailsModel);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Bidder Register Successfully!"
            });
        }
        [HttpPost("login-farmer")]
        public async Task<ActionResult<LoginDto>> LoginAsFarmer([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest();
            }
            var user = await _context.FarmerDetailsModels
                .FirstOrDefaultAsync
                (a => a.FarmerEmail == loginDto.Email && a.FarmerPassword == loginDto.Password);
            if(user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User not found!"
                });
            }
            return Ok(new
            {
                StatusCode = 200,
                Message="Login Success as Farmer"
            });
        }
        [HttpPost("login-bidder")]
        public async Task<ActionResult<LoginDto>> LoginAsBidder([FromBody] LoginDto loginDto)
        {
            if (loginDto == null)
            {
                return BadRequest();
            }
            var user = await _context.BidderDetailsModels
                .FirstOrDefaultAsync
                (a => a.BidderEmail == loginDto.Email && a.BidderPassword == loginDto.Password);
            if (user == null)
            {
                return NotFound(new
                {
                    StatusCode = 404,
                    Message = "User not found!"
                });
            }
            return Ok(new
            {
                StatusCode = 200,
                Message = "Login Success as Bidder"
            });
        }
    }
}

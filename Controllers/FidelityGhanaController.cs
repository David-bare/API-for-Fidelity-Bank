using FidelityGhanaApi.Data;
using FidelityGhanaApi.Request;
using FidelityGhanaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;


namespace FidelityGhanaApi.Controllers
{
    [ApiController]
    [Route("api/FidelityGhana")]
    public class FidelityGhanaController : ControllerBase
    {
        private readonly MyDbContext _db;
        public FidelityGhanaController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_db.digipass_users);
        }

        [HttpPost]
        [Route("validatecard")]
        public async Task<IActionResult> ValidateCard([FromBody] CardValidation card)
        {
            var serverCard = await _db.digipass.FirstOrDefaultAsync(c => c.user_id == card.user_id && c.custum_1 == card.first6digits && c.custum_2 == card.last4digits && c.custum_3 == card.CardPin);
            if (serverCard == null)
            {
                return BadRequest("Invalid data provided. Check your UserID/Card details");
            }
            var user = await _db.digipass_users.FirstOrDefaultAsync(u => u.user_id == serverCard.user_id);

            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }
            var userData = new User
            {
                user_id = user.user_id,
                first_name = user?.first_name?? "",
                last_name = user?.last_name ?? "",
                email = user?.email ?? "",
                phone = user?.phone ?? ""
            };

            return Ok(userData);


        }

        [HttpPost]
        [Route("validateOTP")]
        public async Task<IActionResult> ValidateOtp([FromBody] OTPValidation request)
        {
            var otp = await _db.digipass.FirstOrDefaultAsync(u => u.user_id == request.user_id && u.custum_4 == request.OTP);
            if (otp == null)
            {
                return BadRequest("Invalid UserID/OTP. Please try again.");
            }

            var user = await _db.digipass_users.FirstOrDefaultAsync(u => u.user_id == otp.user_id);
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }
            var userData = new User
            {
                user_id = user.user_id,
                first_name = user.first_name,
                last_name = user.last_name,
                email = user.email,
                phone = user.phone
            };

            return Ok(userData);
        }

        [HttpPost]
        [Route("validateAuthCode")]
        public async Task<IActionResult> ValidateAuthCode([FromBody] AuthorizationCode auth)
        {
            var authCode = await _db.digipass.FirstOrDefaultAsync(u => u.user_id == auth.user_id && u.auth_code == auth.auth_code);
            if (authCode == null)
            {
                return BadRequest("Invalid UserID/Authentication Code. Please try again.");
            }

            var user = await _db.digipass_users.FirstOrDefaultAsync(u => u.user_id == authCode.user_id);
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }
            var userData = new User
            {
                user_id = user.user_id,
                first_name = user.first_name,
                last_name = user.last_name,
                email = user.email,
                phone = user.phone
            };

            return Ok(userData);
        }



    }
}

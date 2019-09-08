using InternetMoviesOnDemand.BusinessAccessLayer.BAL;
using InternetMoviesOnDemand.BusinessAccessLayer.ViewModel;
using InternetMoviesOnDemand.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPNetCoreJWTSample.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBAL _userBAL;
        private UserHelper _userHelper;

        public UserController(IUserBAL userBAL, UserHelper userHelper)
        {
            _userBAL = userBAL;
            _userHelper = userHelper;
        }

        /// <summary>
        /// Method to login a user
        /// </summary>
        /// <param name="loginVM"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginVM login)
        {
            if (ModelState.IsValid)
            {
                var user = _userBAL.Login(login);

                if (user != null)
                {
                    var jwtToken = _userHelper.GenerateToken(user);
                    if (jwtToken != null)
                    {
                        return Ok(jwtToken);
                    }
                }
            }
            return Unauthorized();
        }

        /// <summary>
        /// Method to register a user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(UserVM user)
        {
            if (ModelState.IsValid)
            {
                _userBAL.Register(user);
                return Ok("User successfully added");
            }
            return BadRequest("Username already exist!!");

        }

        /// <summary>
        /// Get all the USers 
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userBAL.GetAllUsers();
            if (users.Count > 0)
                return Ok(users);

            return NotFound();
        }
    }
}
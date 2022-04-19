using DungeonsAndDragonsWeb.Models.Database;
using DungeonsAndDragonsWeb.Models.Resources;
using DungeonsAndDragonsWeb.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DungeonsAndDragonsWeb.Controllers
{
    [ApiController]
    [Route("UserController")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger) { _logger = logger; }

        [HttpPost("Register")]
        public UserResponse Register([FromBody] User u)
        {
            if (string.IsNullOrEmpty(u.Email) || string.IsNullOrEmpty(u.Password)) return new UserResponse(false, "Neither email nor password can be empty!");
            else
            {
                DatabaseDelegator.SetUser(u);
                return new UserResponse(true);
            }
        }

        [HttpPost("Login")]
        public UserResponse Login([FromBody] User u)
        {
            if (string.IsNullOrEmpty(u.Email) || string.IsNullOrEmpty(u.Password)) return new UserResponse(false, "Neither email nor password can be empty!");
            else if (DatabaseDelegator.CheckPassword(u)) return new UserResponse(true);
            else return new UserResponse(false, "User does not exist!");
        }
    }
}
